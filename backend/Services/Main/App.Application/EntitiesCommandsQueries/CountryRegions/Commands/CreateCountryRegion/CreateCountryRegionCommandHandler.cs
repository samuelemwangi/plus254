using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.GetCountryRegion;
using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels;
using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Countries;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.CountryRegions.Commands.CreateCountryRegion
{
    public class CreateCountryRegionCommand: BaseCommand, IRequest<CountryRegionViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CountryId { get; set; }

    }
    internal sealed class CreateCountryRegionCommandHandler : IRequestHandler<CreateCountryRegionCommand, CountryRegionViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;
        private readonly IConfigurationSection _configurationSection;
        private readonly IMachineDateTime _machineDateTime;
        public CreateCountryRegionCommandHandler(AppDbContext appDbContext, IMediator mediator, IConfiguration configuration, IMachineDateTime machineDateTime)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
            _configurationSection = configuration.GetSection("MessageTemplates");
            _machineDateTime = machineDateTime;
        }
        public async Task<CountryRegionViewModel> Handle(CreateCountryRegionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if Country Region exists 
                var countryRegionExists = await _appDbContext.Regions
                    .Where(e => e.Name == request.Name)
                    .AnyAsync(cancellationToken);

                if (countryRegionExists) throw new Exception(_configurationSection["RecordExists"]);


                var countryRegion = new CountryRegion
                {
                    Name = request.Name,
                    Description = request.Description,
                    CountryId =  request.CountryId,
                    CreatedBy = request.UserId,
                    CreatedDate = _machineDateTime.Now,
                    LastEditedBy = request.UserId,
                    LastEditedDate = _machineDateTime.Now

                };

                _appDbContext.Regions.Add(countryRegion);

                await _appDbContext.SaveChangesAsync(cancellationToken);


                return await _mediator.Send(new GetCountryRegionQuery { RegionId= countryRegion.Id }, cancellationToken);

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
