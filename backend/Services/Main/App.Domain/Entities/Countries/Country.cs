using System.Collections.Generic;
/// <summary>
/// Country Entity
/// </summary>
namespace App.Domain.Entities.Countries
{
    public class Country: BaseEntity
    {
        public Country()
        {
            Regions = new HashSet<CountryRegion>();

        }
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegionType { get; set; }

        // Navigation Property
        public ICollection<CountryRegion>  Regions { get; set; }
    }
}