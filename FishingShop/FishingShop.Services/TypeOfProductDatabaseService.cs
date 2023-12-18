using FishingShop.Services.Database;
using FishingShop.Services.Interfaces;
using FishingShop.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingShop.Services
{
    public class TypeOfProductDatabaseService : ITypeOfProductService
    {
        private readonly FishingShopDbContext dbContext;

        public TypeOfProductDatabaseService(FishingShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateTypeOfProductAsync(TypeOfProduct typeOfProduct)
        {
            if (typeOfProduct is null)
            {
                return false;
            }

            try
            {
                await dbContext.Types.AddAsync(new TypeOfProduct
                {
                    ProductTypeName = typeOfProduct.ProductTypeName,
                });
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Task<TypeOfProduct> GetTypeOfProductAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypeOfProduct>> GetTypeOfProductsAsync()
        {
            var types = await dbContext.Types.ToListAsync<TypeOfProduct>();
            return types;
        }

        public Task<bool> RemoveTypeOfProductAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTypeOfProductAsync(TypeOfProduct typeOfProduct)
        {
            throw new NotImplementedException();
        }
    }
}
