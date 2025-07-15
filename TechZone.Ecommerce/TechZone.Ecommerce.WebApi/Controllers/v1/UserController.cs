using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand;
using TechZone.Ecommerce.UseCases.Users.Commands.LastAccessUserCommand;
using TechZone.Ecommerce.UseCases.Users.Queries.GetAllUserQuery;
using TechZone.Ecommerce.UseCases.Users.Queries.GetByEmailUserQuery;

namespace TechZone.Ecommerce.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{ApiVersion:ApiVersion}/user")]
    [Authorize(Roles = "Admin,User")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            if (command == null)
            {
                response.Message = "El cuerpo de la solicitud no puede ser nulo";
                return BadRequest(response);
            }
            response = await _mediator.Send(command, cancellationToken);
            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPatch("set-last-access")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetLastAccessAsync([FromBody] LastAccessUserCommand command, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            if (command == null)
            {
                response.Message = "El cuerpo de la solicitud no puede ser nulo";
                return BadRequest(response);
            }
            response = await _mediator.Send(command, cancellationToken);
            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("get-by-email")]
        [ProducesResponseType(typeof(Response<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<UserDto?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByEmailUser([FromQuery] string email, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetByEmailUserQuery { Email = email }, cancellationToken);
            if (!response.IsSuccess)
                return BadRequest(response);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get-all")]
        [ProducesResponseType(typeof(Response<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<UserDto>?>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
