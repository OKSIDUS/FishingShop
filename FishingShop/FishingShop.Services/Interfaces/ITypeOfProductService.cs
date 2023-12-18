using FishingShop.WebApi.Models;

namespace FishingShop.Services.Interfaces
{
    public interface ITypeOfProductService
    {
        public Task<IEnumerable<TypeOfProduct>> GetTypeOfProductsAsync();

        public Task<TypeOfProduct?> GetTypeOfProductAsync(int typeId);

        public Task<bool> UpdateTypeOfProductAsync(TypeOfProduct typeOfProduct);

        public Task<bool> RemoveTypeOfProductAsync(int typeId);

        public Task<bool> CreateTypeOfProductAsync(TypeOfProduct typeOfProduct);
    }
}
