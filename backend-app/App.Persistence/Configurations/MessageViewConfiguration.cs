using App.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class MessageViewConfiguration : IEntityTypeConfiguration<MessageSummaryView>
    {
        public void Configure(EntityTypeBuilder<MessageSummaryView> builder)
        {
            builder.HasNoKey();
        }
    }
}
