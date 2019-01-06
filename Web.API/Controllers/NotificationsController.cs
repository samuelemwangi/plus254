using App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification;
using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController
    {
        // POST api/customers
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateNotificationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationViewModel>> Get(string id)
        {
            long Id;
            Int64.TryParse(id,out Id);
            return Ok(await Mediator.Send(new GetNotificationQuery { ID = Id }));
        }



    }
}
