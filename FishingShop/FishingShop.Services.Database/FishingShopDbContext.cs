using FishingShop.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingShop.Services.Database
{
    public class FishingShopDbContext : DbContext
    {
        public FishingShopDbContext(DbContextOptions<FishingShopDbContext> options)
            :base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<TypeOfProduct> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfProduct>()
                .HasMany(p => p.Products)
                .WithOne(t => t.TypeOfProduct)
                .HasForeignKey(t => t.TypeOfProductId)
                .IsRequired();
        }

    }
}
