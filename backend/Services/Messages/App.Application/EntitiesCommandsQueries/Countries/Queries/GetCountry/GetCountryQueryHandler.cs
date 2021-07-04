using App.Application.EntitiesCommandsQueries.Countries.Queries.ViewModels;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Messages.Queries.GetCountry
{
    public class GetCountryQuery : BaseQuery, IRequest<CountryDetailViewModel>
    {
        public int CountryId { get; set; }

    }
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryDetailViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;

        public GetCountryQueryHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configurationSection = configuration.GetSection("MessageTemplates");

        }
        public async Task<CountryDetailViewModel> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var country = await _appDbContext.Country
                    .Where(e => e.Id == request.CountryId)
                    .Select(CountryDTO.Projection)
                    .FirstOrDefaultAsync(cancellationToken);

                if (country == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);

                return new CountryDetailViewModel
                {
                    CountryDetails = country,
                    RequestStatus = 1,
                    StatusMessage = _configurationSection["Success"],

                };

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
