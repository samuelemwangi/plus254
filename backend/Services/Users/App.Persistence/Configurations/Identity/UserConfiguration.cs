using App.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Entity config for user
/// </summary>

namespace App.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EmailConfirmationToken).HasMaxLength(200);
            builder.Property(e => e.EmailConfirmationToken);

            builder.Property(e => e.FirstName).HasMaxLength(20);

            builder.Property(e => e.LastName).HasMaxLength(20);

            builder.Property(e => e.UserEmail).HasMaxLength(40);
            builder.HasIndex(e => e.UserEmail);
        }
    }
}
