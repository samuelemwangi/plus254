using App.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations.Notifications
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(e => e.RefId).HasMaxLength(100);
            builder.HasIndex(e => e.RefId);

            builder.Property(e => e.Sender).HasMaxLength(80);
            builder.HasIndex(e => e.Sender);

            builder.Property(e => e.Recipient).HasMaxLength(400);

            builder.Property(e => e.BCCRecipient).HasMaxLength(200);

            builder.Property(e => e.CCRecipient).HasMaxLength(400);

            builder.Property(e => e.Body).HasMaxLength(2000);

            builder.HasOne(p => p.NotificationStatus)
                .WithMany(c => c.Notifications)
                .HasForeignKey(e => e.StatusId);

            builder.HasOne(p => p.NotificationType)
                .WithMany(c => c.Notifications)
                .HasForeignKey(e => e.TypeId);
        }
    }
}
