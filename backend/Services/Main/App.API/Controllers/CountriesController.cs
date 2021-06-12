using App.Application.EntitiesCommandsQueries.Countries.Commands.CreateCountry;
using App.Application.EntitiesCommandsQueries.Countries.Commands.UpdateCountry;
using App.Application.EntitiesCommandsQueries.Countries.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.Messages.Queries.GetCountry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateCountryCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }



        [HttpPut("{countryId}")]
        public async Task<IActionResult> Update(int countryId, [FromBody] UpdateCountryCommand command)
        {
            command.CountryId = countryId;

            return Ok(await Mediator.Send(command));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetailViewModel>> Get(int id)
        {

            return Ok(await Mediator.Send(new GetCountryQuery { CountryId = id }));
        }


    }
}
