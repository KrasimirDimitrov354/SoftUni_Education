namespace ProductShop.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using Models;

public class ProductShopContext : DbContext
{
    public ProductShopContext()
    {

    }

    public ProductShopContext(DbContextOptions options) 
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<CategoryProduct> CategoriesProducts { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(DbConfig.ConnectionString)
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(cp => new { cp.CategoryId, cp.ProductId });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasMany(u => u.ProductsBought)
                .WithOne(u => u.Buyer)
                .HasForeignKey(u => u.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasMany(u => u.ProductsSold)
                .WithOne(u => u.Seller)
                .HasForeignKey(u => u.SellerId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
