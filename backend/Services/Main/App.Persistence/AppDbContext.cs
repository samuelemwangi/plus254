using App.Domain.Entities.Messages;
using App.Persistence.Configurations;
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

        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageStatus> MessageStatuses { get; set; }
        public DbSet<MessageSummaryView> MessagesSummary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageStatusConfiguration());

            // Queries
            modelBuilder.ApplyConfiguration(new MessageViewConfiguration());

            // Entities
            modelBuilder.Entity<Message>().ToTable(_entityKeyPrefix + "message");
            modelBuilder.Entity<MessageStatus>().ToTable(_entityKeyPrefix + "message_status");

            // Views 
            modelBuilder.Entity<MessageSummaryView>().ToView(_entityKeyPrefix + "vw_message_summary");


        }
    }
}
