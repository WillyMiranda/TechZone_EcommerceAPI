using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.SubCategories.Commands.CreateSubCategoryCommand;
using TechZone.Ecommerce.UseCases.SubCategories.Commands.DeleteSubCategoryCommand;
using TechZone.Ecommerce.UseCases.SubCategories.Commands.UpdateSubCategoryCommand;
using TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllByCategorySubCategoryQuery;
using TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllSubCategoryQuery;
using TechZone.Ecommerce.UseCases.SubCategories.Queries.GetByIdSubCategoryQuery;

namespace TechZone.Ecommerce.WebApi.Controllers.v1
{
    [Authorize(Roles = "Admin")]
    [ApiVersion("1.0")]
    [Route("api/v{ApiVersion:ApiVersion}/sub-category")]
    [ApiController]
    public class SubCategoryController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSubCategoryCommand command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateSubCategoryCommand command, CancellationToken cancellationToken)
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

            response = await _mediator.Send(new DeleteSubCategoryCommand { Id = id }, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(typeof(Response<SubCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SubCategoryDto?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetByIdSubCategoryQuery { Id = id }, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpGet("get-all")]
        [ProducesResponseType(typeof(Response<IEnumerable<SubCategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<SubCategoryDto>?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllSubCategoryQuery(), cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get-all-by-category")]
        [ProducesResponseType(typeof(Response<IEnumerable<SubCategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<SubCategoryDto>?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByCategoryAsync([FromQuery] Guid categoryId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllByCategorySubCategoryQuery { CategoryId = categoryId }, cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
