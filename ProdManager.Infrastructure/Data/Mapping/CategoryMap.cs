using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdManager.Domain.Entities;

namespace ProdManager.Infrastructure.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("TB_Category");
        
        builder.HasKey(x => x.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        
    }
}