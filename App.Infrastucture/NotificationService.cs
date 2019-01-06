using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;
using App.Application.Interfaces;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(NotificationViewModel notification)
        {
            return Task.CompletedTask;
        }
    }
}
