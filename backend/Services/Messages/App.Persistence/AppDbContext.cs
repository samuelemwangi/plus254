using App.Domain.Entities.Notifications;
using App.Persistence.Configurations.Notifications;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence
{
    public class AppDbContext : DbContext
    {
        readonly string _entityKeyPrefix = "";


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationStatus> NotificationStatus { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationStatusConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationTypeConfiguration());

            modelBuilder.Entity<Notification>().ToTable(_entityKeyPrefix + "notification");
            modelBuilder.Entity<NotificationStatus>().ToTable(_entityKeyPrefix + "notification_status");
            modelBuilder.Entity<NotificationType>().ToTable(_entityKeyPrefix + "notification_type");
        }
    }
}
