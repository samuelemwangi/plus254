using System.Collections.Generic;

/// <summary>
/// For Counties
/// </summary>
namespace App.Domain.Entities
{
    public class County : BaseEntity
    {
        public County()
        {
            CountyGoverners = new HashSet<CountyGovernor>();

        }
        public string CountyName { get; set; }
        public string CountyDescription { get; set; }

        public ICollection<CountyGovernor> CountyGoverners { get; set; }

    }
}
