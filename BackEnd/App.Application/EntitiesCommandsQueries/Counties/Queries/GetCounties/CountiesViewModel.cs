using App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty;
using System.Collections.Generic;

namespace App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounties
{
    public class CountiesViewModel 
    {
        public IEnumerable<CountyDTO> Counties { get; set; }        
        public bool CreateEnabled { get; set; }

    }
}
