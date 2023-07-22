using AutoMapper;
using Microservice.Services.Catalog.DTOs.Product;
using Microservice.Services.Catalog.Models;
using Microservice.Services.Catalog.Services.Abstract;
using Microservice.Services.Catalog.Settings.Abstract;
using Microservice.Shared.DTOs;
using MongoDB.Driver;

namespace Microservice.Services.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<NoContent>> CreateAsync(CreateProductDTO createProductDTO)
        {
            var values = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(values);

            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(id);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<ResultProductDTO>>> GetAllAsync()
        {
            var values = await _productCollection.Find(value => true).ToListAsync();
            if (values.Any())
            {
                foreach (var item in values)
                {
                    item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstOrDefaultAsync();
                }
            }
            else
            {
                values = new List<Product>();
            }

            return Response<List<ResultProductDTO>>.Success(_mapper.Map<List<ResultProductDTO>>(values), 200);
        }

        public async Task<Response<ResultProductDTO>> GetByIDAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            value.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == value.CategoryID).FirstOrDefaultAsync();

            return Response<ResultProductDTO>.Success(_mapper.Map<ResultProductDTO>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            var values = _mapper.Map<Product>(updateProductDTO);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDTO.ProductID, values);

            return Response<NoContent>.Success(204);
        }
    }
}
