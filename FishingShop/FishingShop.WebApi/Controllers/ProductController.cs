using FishingShop.Services.Interfaces;
using FishingShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FishingShop.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private IProductService service;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

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

            if (product != null)
            {
                var json = JsonSerializer.Serialize(product, options);
                return Ok(json);
            }

            return BadRequest();
        }

        [HttpPost("/Products/Product/Create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (product != null)
            {
                var result = await service.CreateProductAsync(product);
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpPost("/Products/Product/Update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product != null)
            {
                var result = await service.UpdateProductAsync(product);
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpDelete("/Products/Product/Delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if(productId > 0)
            {
                var result = await service.DeleteProductAsync(productId);
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}
