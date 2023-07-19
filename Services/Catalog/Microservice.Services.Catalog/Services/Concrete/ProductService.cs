using AutoMapper;
using Microservice.Services.Catalog.DTOs.Product;
using Microservice.Services.Catalog.Models;
using Microservice.Services.Catalog.Services.Abstract;
using Microservice.Shared.DTOs;
using MongoDB.Driver;

namespace Microservice.Services.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public Task<Response<NoContent>> CreateAsync(CreateProductDTO createProductDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultProductDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultProductDTO>> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            throw new NotImplementedException();
        }
    }
}
