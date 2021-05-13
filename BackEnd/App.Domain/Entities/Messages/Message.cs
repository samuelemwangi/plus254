/// <summary>
/// Message Entity
/// </summary>
namespace App.Domain.Entities.Messages
{
    public class Message: BaseEntity
    {
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public string RecipientId { get; set; }
        public string SenderName { get; set; }
        public string RecipientName { get; set; }
        public short MessageStatusId { get; set; }

        // Navigation Property
        public MessageStatus MessageStatus { get; set; }
    }
}