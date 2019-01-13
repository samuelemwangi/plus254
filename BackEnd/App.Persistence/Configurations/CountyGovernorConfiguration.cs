using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class CountyGovernorConfiguration : IEntityTypeConfiguration<CountyGovernor>
    {
        public void Configure(EntityTypeBuilder<CountyGovernor> builder)
        {
            builder.Property(e => e.GovernorName).HasMaxLength(200);

            builder.HasOne(p => p.County)
                .WithMany(c => c.CountyGoverners)
                .HasForeignKey(f => f.CountyID)
                .HasConstraintName("FK_County_CountyGovernors");

        }
    }
}
