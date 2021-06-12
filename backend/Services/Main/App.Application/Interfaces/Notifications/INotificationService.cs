using System.Threading.Tasks;

namespace App.Application.Interfaces.Notifications
{
    public interface INotificationService
    {
        Task PublishNotificationAsync(string NotificationType, string NotificationLink, string recipientEmail, string recipientName);
    }
}
