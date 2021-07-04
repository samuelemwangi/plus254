using System.Collections.Generic;

namespace App.Domain.Entities.Notifications
{
    public class NotificationStatus: BaseEntity
    {
        public NotificationStatus()
        {
            Notifications = new HashSet<Notification>();
        }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }

        // Navigation property
        public ICollection<Notification> Notifications { get; set; }
    }
}
