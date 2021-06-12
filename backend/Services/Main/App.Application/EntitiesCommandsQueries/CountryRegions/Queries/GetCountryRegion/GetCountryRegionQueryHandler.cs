using App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.CountryRegions.Queries.GetCountryRegion
{
    public class GetCountryRegionQuery : BaseQuery, IRequest<CountryRegionViewModel>
    {
        public int RegionId { get; set; }

    }
    internal sealed class GetCountryRegionQueryHandler: IRequestHandler<GetCountryRegionQuery, CountryRegionViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;
        public GetCountryRegionQueryHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configurationSection = configuration.GetSection("MessageTemplates");
        }

        public async Task<CountryRegionViewModel> Handle(GetCountryRegionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countryRegion = await _appDbContext.Regions
                    .Where(e => e.Id == request.RegionId)
                    .Select(CountryRegionDTO.Projection)
                    .FirstOrDefaultAsync(cancellationToken);


                if (countryRegion == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);

                return new CountryRegionViewModel
                {
                    CountryRegionDetails = countryRegion,
                    StatusMessage = _configurationSection["Success"],
                    RequestStatus = 1,
                    EditEnabled = false,
                    DeleteEnabled = false
                };



            }
            catch (Exception e)
            {
                return new CountryRegionViewModel
                {
                    RequestStatus = 0,
                    StatusMessage = e.Message
                };
            }
            
        }
    }
}
