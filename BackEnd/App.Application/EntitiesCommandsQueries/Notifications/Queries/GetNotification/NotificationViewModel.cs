using App.Domain.Entities;
using System;
using System.Linq.Expressions;


namespace App.Application.EntitiesCommandsQueries.Notifications.Queries.GetNotification
{
    public class NotificationViewModel
    {
        public string SentFrom { get; set; }
        public string SentTo { get; set; }
        public string Subject { get; set; }
        public string NotificationMessage { get; set; }
        public string CreatedBy { get; set; }

        public static Expression<Func<Notification, NotificationViewModel>> Projection
        {
            get
            {
                return notification => new NotificationViewModel
                {
                    SentFrom = notification.From,
                    SentTo = notification.To,
                    Subject = notification.Subject,
                    NotificationMessage = notification.Body,
                    CreatedBy = notification.CreatedBy
                };
            }
        }
    }
}
