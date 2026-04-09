using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyInventory2026.src.modules.products.Infrastructure.Entity;

public sealed class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products");
        builder.HasKey(x => x.id);
        builder.Property(x => x.id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasIndex(x => x.codeInv)
            .IsUnique()
            .HasDatabaseName("IX_products_codeInv");
        builder.Property(x => x.codeInv)
            .HasColumnName("code_inv")
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.Property(x => x.nameProduct)
            .HasColumnName("name_product")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(x => x.stock)
            .HasColumnName("stock")
            .HasColumnType("int")
            .IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_products_stock", "stock > 0"));

        builder.Property(x => x.stockMin)
            .HasColumnName("stock_min")
            .HasColumnType("int")
            .IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_products_stock_min", "stock_min > 0"));

        builder.Property(x => x.stockMax)
            .HasColumnName("stock_max")
            .HasColumnType("int")
            .IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_products_stock_max", "stock_max > stock_min"));

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(200)");
        
        builder.HasMany(p => p.Providers)
            .WithMany(p => p.Products)
            .UsingEntity(j => j.ToTable("ProductProviders"));
    }
}
