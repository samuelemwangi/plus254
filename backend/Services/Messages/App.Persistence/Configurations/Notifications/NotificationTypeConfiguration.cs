using App.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations.Notifications
{
    public class NotificationTypeConfiguration : IEntityTypeConfiguration<NotificationType>
    {
        public void Configure(EntityTypeBuilder<NotificationType> builder)
        {
            builder.Property(e => e.TypeName).HasMaxLength(20);
            builder.HasIndex(e => e.TypeName);

            builder.Property(e => e.TypeDescription).HasMaxLength(100);
        }
    }
}
