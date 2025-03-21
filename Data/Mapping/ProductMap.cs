using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdManager.Entities;

namespace ProdManager.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Tb_Product");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CodeBar).HasMaxLength(13).IsRequired();
            builder.Property(p => p.Supplier).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Lot).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Manufacture).IsRequired();
            builder.Property(p => p.Expiration).IsRequired();

        }
    }
}
