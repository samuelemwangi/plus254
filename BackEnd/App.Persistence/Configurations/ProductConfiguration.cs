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
            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            builder.Property(e => e.UnitsInStock).HasDefaultValue(0);
            builder.Property(e => e.UnitsOnOrder).HasDefaultValue(0);
            builder.Property(e => e.ReorderLevel).HasDefaultValue(0);
            builder.Property(e => e.UnitPrice)
                .HasDefaultValue(0);

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryID)
                .HasConstraintName("FK_Product_Categories");

        }
    }
}
