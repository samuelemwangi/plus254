using App.Application.EntitiesCommandsQueries.Counties.Commands.CreateCounty;
using App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty;
using App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CountiesViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCountiesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountyViewModel>> Get(string id)
        {

            Int64.TryParse(id, out long Id);
            return Ok(await Mediator.Send(new GetCountyQuery { ID = Id }));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody]CreateCountyCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        



    }
}