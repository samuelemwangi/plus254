using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;
using App.Application.Interfaces;

namespace App.Infrastucture
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(NotificationViewModel notification)
        {
            return Task.CompletedTask;
        }
    }
}
