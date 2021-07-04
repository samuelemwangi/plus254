using System.Collections.Generic;
/// <summary>
/// Define notif type  - email, SMS
/// </summary>
namespace App.Domain.Entities.Notifications
{
    public class NotificationType: BaseEntity
    {
        public NotificationType()
        {
            Notifications = new HashSet<Notification>();
        }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        // Navigation property
        public ICollection<Notification> Notifications { get; set; }
    }
}
