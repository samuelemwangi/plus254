using App.Application.Interfaces.Notifications;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace App.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _notificationServiceLogger;


        public NotificationService(ILogger<NotificationService> notificationServiceLogger)
        {
            // Mail jet set up
            _notificationServiceLogger = notificationServiceLogger;
        }

       

        public async Task PublishNotificationAsync(string NotificationType, string NotificationLink, string recipientEmail, string recipientName)
        {
            try
            {

                // Implement sending to queue
                _notificationServiceLogger.LogInformation("*****************************");
                _notificationServiceLogger.LogInformation(NotificationType);
                _notificationServiceLogger.LogInformation(NotificationLink);
                _notificationServiceLogger.LogInformation(recipientEmail);
                _notificationServiceLogger.LogInformation(recipientName);
                _notificationServiceLogger.LogInformation("*****************************");




            }
            catch (Exception e)
            {
                _notificationServiceLogger.LogError(e.StackTrace);
            }
        }
    }
}
