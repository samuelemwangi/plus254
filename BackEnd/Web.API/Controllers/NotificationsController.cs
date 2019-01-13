using App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification;
using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController
    {

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody]CreateNotificationCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationViewModel>> Get(string id)
        {

            Int64.TryParse(id, out long Id);

            return Ok(await Mediator.Send(new GetNotificationQuery { ID = Id }));
        }



    }
}
