using Microservice.Services.Catalog.DTOs.Product;
using Microservice.Shared.DTOs;

namespace Microservice.Services.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDTO>>> GetAllAsync();
        Task<Response<ResultProductDTO>> GetByIDAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateProductDTO createProductDTO);
        Task<Response<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
