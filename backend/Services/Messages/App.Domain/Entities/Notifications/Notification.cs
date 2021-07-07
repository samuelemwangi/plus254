namespace App.Domain.Entities.Notifications
{
    public class Notification : BaseEntity
    {
        public string RefId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string CCRecipient { get; set; }
        public string BCCRecipient { get; set; }

        // FKS
        public long StatusId { get; set; }
        public long TypeId { get; set; }


        // Navigation properties
        public NotificationStatus NotificationStatus { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
