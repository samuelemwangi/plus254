using App.Domain.Entities.Countries;
using System;
using System.Linq.Expressions;


namespace App.Application.EntitiesCommandsQueries.Countries.Queries.ViewModels
{
    public class CountryDTO : BaseEntityDTO
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegionType { get; set; }

        public static Expression<Func<Country, CountryDTO>> Projection
        {
            get
            {
                return c => new CountryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    RegionType = c.RegionType
                };
            }

        }


    }
}
