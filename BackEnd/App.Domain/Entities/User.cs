using App.Domain.ValueObjects;

namespace App.Domain.Entities
{
    public class User : BaseEntity
    {
        public UniqueUserCode UniqueUserCode { get; set; }
    }
}
