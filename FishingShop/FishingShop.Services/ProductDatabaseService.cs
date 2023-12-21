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

        public Task<bool> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
