using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {            
            builder.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CategoryDescription).HasMaxLength(400);
                

            
        }


    }
}
