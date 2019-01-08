using MediatR;
using System;
namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.CreateNotification
{
   public class CreateNotificationCommand:IRequest<long>
   {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
