using System;


namespace App.Domain.Entities
{
    public abstract class BaseEntity
    {

        public long ID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string LastEditedBy { get; set; }

        public DateTime? LastEditedDate { get; set; }

        public short Deleted { get; set; }

    }
}
