using FishingShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FishingShop.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet("/Products")]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await service.GetAllProductsAsync();
            return Ok(products);
        }
    }
}
