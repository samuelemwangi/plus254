using System;

/// <summary>
/// Inherit from this for entities
/// </summary>

namespace App.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
