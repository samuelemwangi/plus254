using App.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace App.Persistence.Configurations
{
    public class CountyConfiguration : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.Property(e => e.CountyName).HasMaxLength(200);
            builder.Property(e => e.CountyDescription).HasMaxLength(800);          

        }
    }
}
