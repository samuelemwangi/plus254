using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels;
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

namespace App.Application.EntitiesCommandsQueries.CountryRegions.Queries.GetCountryRegions
{
    public class GetCountryRegionsQuery: BaseQuery, IRequest<CountryRegionsViewModel>
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
    internal sealed class GetCountryRegionsCommandHandler : IRequestHandler<GetCountryRegionsQuery, CountryRegionsViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;
        public GetCountryRegionsCommandHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configurationSection = configuration.GetSection("MessageTemplates");
        }
        public async Task<CountryRegionsViewModel> Handle(GetCountryRegionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countryRegions = await _appDbContext.Regions
                    .Where(e => e.Country.Id == request.CountryId || e.Country.Name == request.CountryName)
                    .Select(CountryRegionDTO.Projection)
                    .ToListAsync(cancellationToken);

                return new CountryRegionsViewModel
                {
                    CountryRegions = countryRegions,
                    CreateEnabled = false,
                    DownloadEnabled = false,
                    RequestStatus = 1,
                    StatusMessage = countryRegions.Count > 0 ? _configurationSection["Success"] : _configurationSection["ItemsNotFound"]

                };
            }
            catch (Exception e)
            {

                return new CountryRegionsViewModel
                {
                    RequestStatus = 0,
                    StatusMessage = e.Message
                };
            }
        }
    }
}
