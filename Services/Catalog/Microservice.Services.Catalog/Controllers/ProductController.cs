using Microservice.Services.Catalog.DTOs.Category;
using Microservice.Services.Catalog.DTOs.Product;
using Microservice.Services.Catalog.Services.Abstract;
using Microservice.Services.Catalog.Services.Concrete;
using Microservice.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productService.GetAllAsync();
            return CreateActionResultInstance(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO createProductDTO)
        {
            var value = await _productService.CreateAsync(createProductDTO);
            return CreateActionResultInstance(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var value = await _productService.DeleteAsync(id);
            return CreateActionResultInstance(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var value = await _productService.UpdateAsync(updateProductDTO);
            return CreateActionResultInstance(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDProduct(string id)
        {
            var value = await _productService.GetByIDAsync(id);
            return CreateActionResultInstance(value);
        }
    }
}
