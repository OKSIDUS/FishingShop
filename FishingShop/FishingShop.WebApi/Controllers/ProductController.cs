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

        [HttpGet("/Products/Product/{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var product = await service.GetProductAsync(productId);

            if(product != null)
            {
                return Ok(product);
            }

            return BadRequest();
        }
    }
}
