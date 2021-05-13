using App.Application.EntitiesCommandsQueries.Messages.Commands.CreateMessage;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers.Messages
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class HireUsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateMessageCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

    }
}
