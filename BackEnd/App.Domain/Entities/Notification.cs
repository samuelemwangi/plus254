namespace App.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
