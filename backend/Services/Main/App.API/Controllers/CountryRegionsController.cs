using App.Application.EntitiesCommandsQueries.CountryRegions.Commands.CreateCountryRegion;
using App.Application.EntitiesCommandsQueries.CountryRegions.Commands.UpdateCountryRegion;
using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.GetCountryRegion;
using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.GetCountryRegions;
using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegionsController : BaseController
    {


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateCountryRegionCommand command)
        {
            return Created(CurrentUri, await Mediator.Send(command));
        }



        [HttpPut("{countryId}")]
        public async Task<IActionResult> Update(int countryRegionId, [FromBody] UpdateCountryRegionCommand command)
        {
            command.RegionId = countryRegionId;

            return Ok(await Mediator.Send(command));

        }

        [HttpGet("{countryId}/{countryName}")]
        public async Task<ActionResult<CountryRegionViewModel>> GetAll(int countryId, string countryName)
        {

            return Ok(await Mediator.Send(new GetCountryRegionsQuery { CountryId = countryId, CountryName = countryName }));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CountryRegionViewModel>> Get(int id)
        {

            return Ok(await Mediator.Send(new GetCountryRegionQuery { RegionId = id }));
        }


    }
}
