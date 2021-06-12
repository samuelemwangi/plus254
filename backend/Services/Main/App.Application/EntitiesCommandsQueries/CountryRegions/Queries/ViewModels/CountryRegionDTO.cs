using App.Domain.Entities.Countries;
using System;
using System.Linq.Expressions;

/// <summary>
/// Country Region DTO 
/// </summary>

namespace App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels
{
    public class CountryRegionDTO: BaseEntityDTO
    {
        public new int Id { get; set; }
        public string RegionName { get; set; }
        public string RegionDescription { get; set; }
        public string CountryName { get; set; }

        public static Expression<Func<CountryRegion, CountryRegionDTO>> Projection
        {
            get
            {
                return cR => new CountryRegionDTO
                {
                    Id =  cR.Id,
                    RegionName = cR.Name,
                    RegionDescription = cR.Description,
                    CountryName = cR.Country.Name
                };
            }
        }


    }
}
