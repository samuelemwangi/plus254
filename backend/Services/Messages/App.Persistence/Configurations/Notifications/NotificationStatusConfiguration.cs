using App.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations.Notifications
{
    public class NotificationStatusConfiguration : IEntityTypeConfiguration<NotificationStatus>
    {
        public void Configure(EntityTypeBuilder<NotificationStatus> builder)
        {
            builder.Property(e => e.StatusName).HasMaxLength(100);
            builder.HasIndex(e => e.StatusName);

            builder.Property(e => e.StatusDescription).HasMaxLength(100);
        }
    }
}
