using App.Application.EntitiesCommandsQueries.Categories.Commands.CreateCategory;
using App.Application.EntitiesCommandsQueries.Categories.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody]CreateCategoryCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> Get(string id)
        {
            long Id;
            Int64.TryParse(id, out Id);

            return Ok(await Mediator.Send(new GetCategoryQuery { ID = Id }));
        }



    }
}