using FishingShop.Services.Interfaces;
using FishingShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishingShop.WepApp.Controllers
{
    public class TypeOfProductController : Controller
    {
        private readonly ITypeOfProductService service;

        public TypeOfProductController(ITypeOfProductService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var types = await service.GetTypeOfProductsAsync();
            return View((TypeOfProduct)types);
        }
    }
}
