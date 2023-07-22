using Microservice.Services.Catalog.DTOs.Category;
using Microservice.Services.Catalog.Services.Abstract;
using Microservice.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO createCategoryDTO)
        {
            var value = await _categoryService.CreateAsync(createCategoryDTO);
            return CreateActionResultInstance(value);
        }
    }
}
