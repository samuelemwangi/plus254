using App.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace App.Persistence.Configurations
{
    public class MessageStatusConfiguration : IEntityTypeConfiguration<MessageStatus>
    {
        public void Configure(EntityTypeBuilder<MessageStatus> builder)
        {
            builder.Property(e => e.StatusLabel).HasMaxLength(20);
            builder.Property(e => e.StatusDescription).HasMaxLength(100);
        }
    }
}
