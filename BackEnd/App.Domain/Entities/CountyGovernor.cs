using System;

/// <summary>
/// For County Governors
/// </summary>

namespace App.Domain.Entities
{
    public class CountyGovernor : BaseEntity
    {

        public string GovernorName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Foreign Key
        public long? CountyID { get; set; }

        public County County { get; set; }

    }
}
