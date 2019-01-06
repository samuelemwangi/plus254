using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.ProductName).IsRequired().HasMaxLength(40);
            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            builder.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            builder.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Categories");

        }
    }
}
