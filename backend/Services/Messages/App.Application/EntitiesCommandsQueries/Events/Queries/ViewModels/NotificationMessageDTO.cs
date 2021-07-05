namespace App.Application.EntitiesCommandsQueries.Events.Queries.ViewModels
{
    public class NotificationMessageDTO
    {
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string NotificationType { get; set; }
        public string EmailLink { get; set; }
    }
}
