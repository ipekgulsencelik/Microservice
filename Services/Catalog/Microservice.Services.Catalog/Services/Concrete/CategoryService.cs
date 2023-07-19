using AutoMapper;
using Microservice.Services.Catalog.DTOs.Category;
using Microservice.Services.Catalog.Models;
using Microservice.Services.Catalog.Services.Abstract;
using Microservice.Shared.DTOs;
using MongoDB.Driver;

namespace Microservice.Services.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public Task<Response<NoContent>> CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultCategoryDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultCategoryDTO>> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
