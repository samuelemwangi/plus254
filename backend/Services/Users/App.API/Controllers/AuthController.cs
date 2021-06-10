using App.Application.EntitiesCommandsQueries.Users.Commands.ExchangeRefreshToken;
using App.Application.EntitiesCommandsQueries.Users.Commands.LoginUser;
using App.Application.EntitiesCommandsQueries.Users.Commands.ResetPassword;
using App.Application.EntitiesCommandsQueries.Users.Commands.UpdateUserPassword;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: BaseController
    {
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] LoginUserCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] ExchangeRefreshTokenCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [HttpPost("ResetPassword")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] ResetPasswordCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [HttpPost("UpdatePassword")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] UpdateUserPasswordCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }
    }
}
