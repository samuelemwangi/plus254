using App.Application.EntitiesCommandsQueries.Countries.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.Messages.Queries.GetCountry;
using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Countries;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : BaseCommand, IRequest<CountryDetailViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegionType { get; set; }
    }
    internal sealed class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryDetailViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;
        private readonly IConfigurationSection _configurationSection;
        private readonly IMachineDateTime _machineDateTime;

        public CreateCountryCommandHandler(AppDbContext appDbContext, IMediator mediator, IConfiguration configuration, IMachineDateTime machineDateTime)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
            _configurationSection = configuration.GetSection("MessageTemplates");
            _machineDateTime = machineDateTime;
        }
        public async Task<CountryDetailViewModel> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if Country exists 
                var countryExists = await _appDbContext.Country
                    .Where(e => e.Name == request.Name)
                    .AnyAsync(cancellationToken);

                if (countryExists) throw new Exception(_configurationSection["RecordExists"]);


                var country = new Country
                {
                    Name = request.Name,
                    Description = request.Description,
                    RegionType = request.RegionType,
                    CreatedBy = request.UserId,
                    CreatedDate = _machineDateTime.Now,
                    LastEditedBy = request.UserId,
                    LastEditedDate = _machineDateTime.Now

                };

                _appDbContext.Country.Add(country);

                await _appDbContext.SaveChangesAsync(cancellationToken);


                return await _mediator.Send(new GetCountryQuery { CountryId = country.Id }, cancellationToken);

            }
            catch (Exception e)
            {

                return new CountryDetailViewModel
                {
                    RequestStatus = 0,
                    StatusMessage = e.Message

                };
            }
        }
    }
}
