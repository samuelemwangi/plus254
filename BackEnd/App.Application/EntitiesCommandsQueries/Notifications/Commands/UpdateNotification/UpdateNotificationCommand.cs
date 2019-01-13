using MediatR;

namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationCommand: IRequest
    {
        public long ID { get; set; }
        public short MailQueued { get; set; }
    }
}
