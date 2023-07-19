using Microservice.Services.Catalog.DTOs.Category;
using Microservice.Shared.DTOs;

namespace Microservice.Services.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDTO>>> GetAllAsync();
        Task<Response<ResultCategoryDTO>> GetByIDAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateCategoryDTO createCategoryDTO);
        Task<Response<NoContent>> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
