using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Users.Commands.CreateUser;
using JiraClone.Application.Features.Users.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JiraClone.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInUserCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
        }
    }
}
