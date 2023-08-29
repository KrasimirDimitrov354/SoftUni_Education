using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using SoftUniBazar.Models;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext<BazaarUser>
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<AdBuyer> AdsBuyers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Ads)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Owner)
                .WithMany(o => o.OwnedAds)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Buyer)
                .WithMany(b => b.BoughtAds)
                .HasForeignKey(a => a.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ad>()
                .Property(a => a.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Ad>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<AdBuyer>()
                .HasKey(ab => new { ab.AdId, ab.BuyerId });

            base.OnModelCreating(modelBuilder);
        }
    }
}