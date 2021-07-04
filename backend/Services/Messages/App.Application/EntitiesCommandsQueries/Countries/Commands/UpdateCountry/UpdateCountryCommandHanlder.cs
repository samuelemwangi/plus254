using App.Application.EntitiesCommandsQueries.Countries.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.Messages.Queries.GetCountry;
using App.Application.Interfaces.Utilities;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : BaseCommand, IRequest<CountryDetailViewModel>
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegionType { get; set; }

    }
    internal sealed class UpdateCountryCommandHanlder : IRequestHandler<UpdateCountryCommand, CountryDetailViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;
        private readonly IConfigurationSection _configurationSection;
        private readonly IMachineDateTime _machineDateTime;
        public UpdateCountryCommandHanlder(AppDbContext appDbContext, IMediator mediator, IConfiguration configuration, IMachineDateTime machineDateTime)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
            _configurationSection = configuration.GetSection("MessageTemplates");
            _machineDateTime = machineDateTime;
        }
        public async Task<CountryDetailViewModel> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Check if Country exists 
                var country = await _appDbContext.Country
                    .Where(e => e.Id == request.CountryId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (country == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);



                country.Name = request.Name ?? country.Name;
                country.Description = request.Description ?? country.Description;
                country.RegionType = request.RegionType ?? country.RegionType;
                country.LastEditedDate = _machineDateTime.Now;
                country.LastEditedBy = request.UserId;


                _appDbContext.Country.Update(country);

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
