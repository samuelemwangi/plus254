using App.Domain.Entities.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class CountryRegionConfiguration : IEntityTypeConfiguration<CountryRegion>
    {
        public void Configure(EntityTypeBuilder<CountryRegion> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(20);
            builder.Property(e => e.Description).HasMaxLength(200);


            builder.HasOne(p => p.Country)
                .WithMany(c => c.Regions)
                .HasForeignKey(e => e.CountryId);
        }
    }
}
