using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification;

namespace App.Application.Interfaces
{
    public interface INotificationService
    {
         Task SendAsync(NotificationViewModel notification);
        
    }
}
