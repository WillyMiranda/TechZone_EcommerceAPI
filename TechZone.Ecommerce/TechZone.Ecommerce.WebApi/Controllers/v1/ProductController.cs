using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.Categories.Queries.GetAllCategoryQuery;
using TechZone.Ecommerce.UseCases.Categories.Queries.GetByIdCategoryQuery;
using TechZone.Ecommerce.UseCases.Products.Commands.CreateProductCommand;
using TechZone.Ecommerce.UseCases.Products.Commands.DeleteProductCommand;
using TechZone.Ecommerce.UseCases.Products.Commands.UpdateProductCommand;
using TechZone.Ecommerce.UseCases.Products.Queries.GetAllProductQuery;
using TechZone.Ecommerce.UseCases.Products.Queries.GetByIdProductQuery;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TechZone.Ecommerce.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ApiVersion:ApiVersion}/product")]
    [ApiController]
    public class ProductController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            if (command == null)
            {
                response.Message = "El cuerpo de la solicitud no puede ser nulo";
                return BadRequest(response);
            }
            response = await _mediator.Send(command, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            if (command == null)
            {
                response.Message = "El cuerpo de la solicitud no puede ser nulo";
                return BadRequest(response);
            }

            command.Id = id;
            response = await _mediator.Send(command, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPatch("delete/{id}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            response = await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(typeof(Response<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ProductDto?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdProductQuery { Id = id }, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get-all-with-pagination")]
        [ProducesResponseType(typeof(ResponsePagination<IEnumerable<ProductDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponsePagination<IEnumerable<ProductDto>?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<ProductDto>>();
            if (query == null)
            {
                response.Message = "El cuerpo de la solicitud no puede ser nulo";
                return BadRequest(response);
            }
            response = await _mediator.Send(query, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
