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

        public async Task<TypeOfProduct?> GetTypeOfProductAsync(int typeId)
        {
            var typeOfProduct = await dbContext.Types.Where(t => t.Id == typeId).FirstOrDefaultAsync();

            if(typeOfProduct is null)
            {
                return null;
            }

            return typeOfProduct;
        }

        public async Task<IEnumerable<TypeOfProduct>> GetTypeOfProductsAsync()
        {
            var types = await dbContext.Types.ToListAsync<TypeOfProduct>();
            return types;
        }

        public async Task<bool> RemoveTypeOfProductAsync(int typeId)
        {
            if (typeId > 0)
            {
                var typeOfProduct = await dbContext.Types.Where(t => t.Id == typeId).FirstOrDefaultAsync();

                if (typeOfProduct != null)
                {
                    dbContext.Types.Remove(typeOfProduct);
                    dbContext.SaveChanges();
                    return true;
                }
            }

            return false;

        }

        public Task<bool> UpdateTypeOfProductAsync(TypeOfProduct typeOfProduct)
        {
            throw new NotImplementedException();
        }
    }
}
