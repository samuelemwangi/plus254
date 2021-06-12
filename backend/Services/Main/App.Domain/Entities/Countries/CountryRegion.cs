/// <summary>
/// Region e.g County, State, 
/// </summary>

namespace App.Domain.Entities.Countries
{
    public class CountryRegion : BaseEntity
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
