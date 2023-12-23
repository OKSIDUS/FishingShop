using AutoMapper;
using FishingShop.WebApi.Models;
using FishingShop.WepApp.Models;

namespace FishingShop.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TypeOfProduct, TypeOfProductModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
