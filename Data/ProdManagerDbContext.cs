using Microsoft.EntityFrameworkCore;
using ProdManager.Data.Mapping;
using ProdManager.Entities;

namespace ProdManager.Data
{
    public class ProdManagerDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

       public ProdManagerDbContext(DbContextOptions<ProdManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Entity<User>()
                .HasIndex(u =>u.Registration)
                .IsUnique();
        }
    }
}
