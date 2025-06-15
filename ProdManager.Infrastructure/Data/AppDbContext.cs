using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProdManager.Domain.Entities;

namespace ProdManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}
   
   public DbSet<User> Users { get; set; }
   public DbSet<Category> Categories { get; set; }
   public DbSet<Product> Products { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>()
         .HasIndex(u => u.Email)
         .IsUnique();
      
      modelBuilder.Entity<User>()
         .HasIndex(u => u.Registration)
         .IsUnique();
   }
}