using App.Domain.Enums;

namespace App.Application.EntitiesCommandsQueries.NotificationMessages.Queries.ViewModels
{
    public class NotificationMessageDTO
    {
        public string MessageType { get; set; }
        public string Recipient { get; set; }
        public string RecipientName { get; set; }
        public NotificationMessageType NotifType { get; set; }
        public string MessageLink { get; set; }
        public string CustomMessage { get; set; }
    }
}
