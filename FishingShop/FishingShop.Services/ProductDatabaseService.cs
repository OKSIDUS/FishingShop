using FishingShop.Services.Database;
using FishingShop.Services.Interfaces;
using FishingShop.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingShop.Services
{
    public class ProductDatabaseService : IProductService
    {
        private readonly FishingShopDbContext dbContext;

        public ProductDatabaseService(FishingShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            if (product != null)
            {
                await dbContext.Products.AddAsync(new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    TypeOfProductId = product.TypeOfProductId,
                    TypeOfProduct = product.TypeOfProduct,
                    Price = product.Price,
                    Count = product.Count,
                });
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            if (productId > 0)
            {
                var product = await dbContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
                if (product != null)
                {
                    dbContext.Remove(product);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            var product = await dbContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();

            if(product != null)
            {
                return product;
            }

            return null;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            if(product != null)
            {
                var checkProduct = await dbContext.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefaultAsync();
                if(checkProduct != null)
                {
                    dbContext.Entry(checkProduct).CurrentValues.SetValues(product);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
