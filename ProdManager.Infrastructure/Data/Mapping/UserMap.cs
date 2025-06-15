using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdManager.Domain.Entities;

namespace ProdManager.Infrastructure.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("TB_User");
        
        builder.HasKey(x => x.Id);
        builder.Property(u => u.Registration);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.Address);
        builder.Property(u => u.Phone);
        builder.Property(u => u.IsActive);

    }
}