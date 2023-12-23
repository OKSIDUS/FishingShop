using FishingShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FishingShop.WebApp.Controllers
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

            return View(types);
        }
    }
}
