using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleCRUD.Domain;

namespace SampleCRUD.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c=>c.ManufacturePhone)
            .HasMaxLength(11);

        builder.Property(c => c.ManufactureEmail)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(c => new { c.ManufactureEmail, c.ProduceDate })
          .IsUnique()
          .HasName("ProduceDateAndEmailIndex");
    }
}
