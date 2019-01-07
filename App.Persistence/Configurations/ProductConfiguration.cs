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
            builder.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
            builder.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");
            builder.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            builder.Property(e => e.UnitPrice)
                .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryID)
                .HasConstraintName("FK_Product_Categories");

        }
    }
}
