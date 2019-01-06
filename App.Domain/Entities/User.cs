using App.Domain.ValueObjects;

namespace App.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public UniqueUserCode UniqueUserCode { get; set; }
    }
}
