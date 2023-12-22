using FishingShop.Services.Interfaces;
using FishingShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FishingShop.WebApi.Controllers
{
    public class TypeOfProductController : Controller
    {
        private readonly ITypeOfProductService service;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        public TypeOfProductController(ITypeOfProductService service)
        {
            this.service = service;
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetAll()
        {
            var types = await service.GetTypeOfProductsAsync();
            if(types != null)
            {
                return Ok(types);
            }

            return BadRequest();
        }

        [HttpGet("/TypeOfProduct/{typeId}")]
        public async Task<IActionResult> GetTypeOfProduct(int typeId)
        {
            var typeOfProduct = await service.GetTypeOfProductAsync(typeId);
            if(typeOfProduct != null)
            {
                var json = JsonSerializer.Serialize(typeOfProduct, options);
                return Ok(json);
            }

            return BadRequest();
        }

        [HttpPost("/TypeOfProduct/Create")]
        public async Task<IActionResult> Create(TypeOfProduct typeOfProduct)
        {
            if (typeOfProduct is null)
            {
                return BadRequest();
            }

            var result = await service.CreateTypeOfProductAsync(typeOfProduct);
            if (result)
            {
                return Ok(typeOfProduct);
            }

            return BadRequest();
        }

        [HttpDelete("/TypeOfProduct/Delete/{typeId}")]
        public async Task<IActionResult> Delete(int typeId)
        {
            if (typeId > 0)
            {
                var result = await service.RemoveTypeOfProductAsync(typeId);
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpPost("/TypeOfProduct/Update")]
        public async Task<IActionResult> Update(TypeOfProduct typeOfProduct)
        {
            if (typeOfProduct != null)
            {
                var result = await service.UpdateTypeOfProductAsync(typeOfProduct);
                if (result)
                {
                    return Ok(typeOfProduct);
                }
            }

            return BadRequest();
        }
    }
}
