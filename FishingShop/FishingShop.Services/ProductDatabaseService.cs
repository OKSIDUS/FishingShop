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
