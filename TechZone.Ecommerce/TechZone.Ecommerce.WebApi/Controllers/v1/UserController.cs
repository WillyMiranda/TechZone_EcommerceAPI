using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand;

namespace TechZone.Ecommerce.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{ApiVersion:ApiVersion}/user")]
    [AllowAnonymous]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
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
    }
}
