using MediatR;

namespace App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification
{
    public class GetNotificationQuery : IRequest<NotificationViewModel>
    {
        public long ID { get; set; }

    }
}
