using App.Domain.Entities;
using System;
using System.Linq.Expressions;


namespace App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty
{
    public class CountyDTO
    {
        public long ID { get; set; }
        public string CountyName { get; set; }
        public string CountyDescription { get; set; }

        public static Expression<Func<County, CountyDTO>> Projection
        {
            get
            {
                return county => new CountyDTO
                {
                    ID = county.ID,
                    CountyName = county.CountyName,
                    CountyDescription = county.CountyDescription
                };
            }
        }

    }


}
