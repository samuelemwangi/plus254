using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.GetCountryRegion;
using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels;
using App.Application.Interfaces.Utilities;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.CountryRegions.Commands.UpdateCountryRegion
{
    public class UpdateCountryRegionCommand : BaseCommand, IRequest<CountryRegionViewModel>
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal sealed class UpdateCountryRegionCommandHandler : IRequestHandler<UpdateCountryRegionCommand, CountryRegionViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;
        private readonly IConfigurationSection _configurationSection;
        private readonly IMachineDateTime _machineDateTime;
        public UpdateCountryRegionCommandHandler(AppDbContext appDbContext, IMediator mediator, IConfiguration configuration, IMachineDateTime machineDateTime)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
            _configurationSection = configuration.GetSection("MessageTemplates");
            _machineDateTime = machineDateTime;
        }
        public async Task<CountryRegionViewModel> Handle(UpdateCountryRegionCommand request, CancellationToken cancellationToken)
        {
            try
            { // Check if Country Region ntry exists 
                var countryRegion = await _appDbContext.Regions
                    .Where(e => e.Id == request.RegionId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (countryRegion == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);



                countryRegion.Name = request.Name ?? countryRegion.Name;
                countryRegion.Description = request.Description ?? countryRegion.Description;
                countryRegion.LastEditedDate = _machineDateTime.Now;
                countryRegion.LastEditedBy = request.UserId;


                _appDbContext.Regions.Update(countryRegion);

                await _appDbContext.SaveChangesAsync(cancellationToken);


                return await _mediator.Send(new GetCountryRegionQuery { RegionId = countryRegion.Id }, cancellationToken);


            }
            catch (Exception e)
            {

                return new CountryRegionViewModel
                {
                    StatusMessage = e.Message,
                    RequestStatus = 0
                };
            }
        }
    }
}
