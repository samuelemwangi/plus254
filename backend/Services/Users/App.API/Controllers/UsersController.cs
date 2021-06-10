using App.Application.EntitiesCommandsQueries.Users.Commands.ConfirmEmail;
using App.Application.EntitiesCommandsQueries.Users.Commands.RegisterUser;
using App.Application.EntitiesCommandsQueries.Users.Queries.GetUser;
using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Authorize(Roles = "Admin, AppUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] RegisterUserCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }


        [AllowAnonymous]
        [HttpPost("ConfirmEmail")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(string id)
        {

            return Ok(await Mediator.Send(new GetUserQuery { UserId = id }));
        }


    }
}
