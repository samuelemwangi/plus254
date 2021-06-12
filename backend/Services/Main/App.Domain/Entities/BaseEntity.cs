using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Inherit from this for entities
/// </summary>

namespace App.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(50)]
        public string LastEditedBy { get; set; }

        public DateTime? LastEditedDate { get; set; }

        [MaxLength(50)]
        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

    }

}
