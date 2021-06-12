using System.Collections.Generic;

/// <summary>
/// Get Regions
/// </summary>

namespace App.Application.EntitiesCommandsQueries.CountryRegions.Queries.ViewModels
{
    public class CountryRegionsViewModel : ItemsBaseViewModel
    {
        public ICollection<CountryRegionDTO> CountryRegions { get; set; }

    }
}
