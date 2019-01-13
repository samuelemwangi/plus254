using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(e => e.ProductName).IsRequired().HasMaxLength(40);
            builder.Property(e => e.ProductDescription).HasMaxLength(800);

            builder.HasOne(d => d.ProductCategory)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryID)
                .HasConstraintName("FK_Product_Categories");

        }
    }
}
