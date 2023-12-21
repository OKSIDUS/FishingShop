using FishingShop.WebApi.Models;

namespace FishingShop.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();

        public Task<Product> GetProductAsync(int productId);

        public Task<bool> CreateProductAsync(Product product);

        public Task<bool> UpdateProductAsync(Product product);

        public Task<bool> DeleteProductAsync(Product product);
    }
}
