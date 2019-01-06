using MediatR;

namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification
{
    public class NotificationCreated : INotification
    {
        public long ID {get;set;}

        
    }
    
}