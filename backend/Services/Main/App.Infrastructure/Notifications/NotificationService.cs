﻿using App.Application.Interfaces.Notifications;
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

        public async Task PublishNotificationAsync(string subject, string mailText, string recipientEmail, string recipientName, bool showSenderTitleInSubject)
        {
            try
            {

                // Implement sending to queue
                _notificationServiceLogger.LogInformation("*****************************");
                _notificationServiceLogger.LogInformation(subject);
                _notificationServiceLogger.LogInformation(mailText);
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
