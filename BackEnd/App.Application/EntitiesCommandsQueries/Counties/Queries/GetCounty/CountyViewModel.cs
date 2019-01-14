using App.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty
{
    public class CountyViewModel : CountyDTO
    {

        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }


        public new static Expression<Func<County, CountyDTO>> Projection
        {
            get
            {
                return county => new CountyViewModel
                {
                    ID = county.ID,
                    CountyName = county.CountyName,
                    CountyDescription = county.CountyDescription


                };
            }
        }
    }

}
