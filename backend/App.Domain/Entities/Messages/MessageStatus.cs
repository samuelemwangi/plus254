using System.Collections.Generic;

/// <summary>
/// Message Status
/// </summary>

namespace App.Domain.Entities.Messages
{
    public class MessageStatus: BaseEntity
    {
        public MessageStatus()
        {
            MessageItems = new HashSet<Message>();
        }
        public new short Id { get; set; }
        public string StatusLabel { get; set; }
        public string StatusDescription { get; set; }
        public ICollection<Message> MessageItems { get; set; }
    }
}
