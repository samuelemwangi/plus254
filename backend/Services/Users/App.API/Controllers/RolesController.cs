using App.Application.EntitiesCommandsQueries.Roles.Commands.CreateRole;
using App.Application.EntitiesCommandsQueries.Roles.Queries.GetRole;
using App.Application.EntitiesCommandsQueries.Roles.Queries.GetRoles;
using App.Application.EntitiesCommandsQueries.Roles.Queries.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController
    {
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<RolesViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetRolesQuery()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewModel>> Get(string roleName)
        {

            return Ok(await Mediator.Send(new GetRoleQuery { RoleName = roleName }));
        }
    }
}
