using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorExcelCsv.Infrastructure.Data.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
  public void Configure(EntityTypeBuilder<Item> builder)
  {
    builder.ToTable("Items");

    builder.HasKey(x => x.SKU);

    builder.Property(x => x.SKU)
        .HasConversion(
            sku => sku.Code,
            value => new SKU(value))
        .HasMaxLength(50)
        .ValueGeneratedNever()
        .HasColumnName("SKU");

    builder.Property(x => x.Name)
        .IsRequired()
        .HasMaxLength(200);

    builder.Property(x => x.Price)
        .HasPrecision(18, 2)
        .IsRequired();

    builder.Property(x => x.Stock)
        .IsRequired();

    builder.Property(x => x.Category)
        .HasConversion<string>()
        .HasMaxLength(50)
        .IsRequired();

    builder.Property(x => x.Active)
        .IsRequired();
  }
}