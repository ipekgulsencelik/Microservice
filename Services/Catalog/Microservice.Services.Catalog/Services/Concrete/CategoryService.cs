using AutoMapper;
using Microservice.Services.Catalog.DTOs.Category;
using Microservice.Services.Catalog.Models;
using Microservice.Services.Catalog.Services.Abstract;
using Microservice.Services.Catalog.Settings.Abstract;
using Microservice.Shared.DTOs;
using MongoDB.Driver;

namespace Microservice.Services.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
            var values = _mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(values);

            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultCategoryDTO>>> GetAllAsync()
        {
            var values = await _categoryCollection.Find(value => true).ToListAsync();
            return Response<List<ResultCategoryDTO>>.Success(_mapper.Map<List<ResultCategoryDTO>>(values), 200);
        }

        public async Task<Response<ResultCategoryDTO>> GetByIDAsync(string id)
        {
            var value = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultCategoryDTO>.Fail("Kategori Bulunamadı", 404);
            }

            return Response<ResultCategoryDTO>.Success(_mapper.Map<ResultCategoryDTO>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var value = _mapper.Map<Category>(updateCategoryDTO);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDTO.CategoryID, value);

            return Response<NoContent>.Success(200);
        }
    }
}
