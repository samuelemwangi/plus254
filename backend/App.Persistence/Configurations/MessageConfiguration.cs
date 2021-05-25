using App.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(e => e.MessageTitle).HasMaxLength(50);
            builder.Property(e => e.MessageContent).HasMaxLength(400);

            builder.HasIndex(e => e.RecipientId);


            builder.Property(e => e.RecipientId).HasMaxLength(50);

            builder.HasOne(p => p.MessageStatus)
                .WithMany(c => c.MessageItems)
                .HasForeignKey(e => e.MessageStatusId);

        }
    }
}
