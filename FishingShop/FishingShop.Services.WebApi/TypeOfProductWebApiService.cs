using FishingShop.Services.Interfaces;
using FishingShop.WebApi.Models;
using System.Net.Http.Json;

namespace FishingShop.Services.WebApi
{
    public class TypeOfProductWebApiService : ITypeOfProductService
    {
        private static readonly HttpClient HttpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7181"),
        };
        public Task<bool> CreateTypeOfProductAsync(TypeOfProduct typeOfProduct)
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfProduct?> GetTypeOfProductAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypeOfProduct>> GetTypeOfProductsAsync()
        {
            var response = await HttpClient.GetAsync("/");

            if (response.IsSuccessStatusCode)
            {
                var typeOfProducts = await response.Content.ReadFromJsonAsync<IEnumerable<TypeOfProduct>>();
                if (typeOfProducts != null)
                {
                    return typeOfProducts;
                }
            }

            return new List<TypeOfProduct>();
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
