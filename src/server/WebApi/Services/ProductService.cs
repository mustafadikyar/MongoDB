using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Configurations;
using WebApi.Models;

namespace WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> products = await _productCollection.Find(product => true).ToListAsync();
            if (products.Any())
            {
                products.ForEach(async product =>
                {
                    product.Category = await _categoryCollection.Find<Category>(category => category.CategoryId == product.CategoryID).FirstAsync();
                });

                return products;
            }

            return new();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            Product product = await _productCollection.Find<Product>(product => product.ProductID == id).FirstOrDefaultAsync();

            if (product != null)
            {
                product.Category = await _categoryCollection.Find<Category>(category => category.CategoryId == product.CategoryID).FirstAsync();
                return product;
            }

            return new();
        }

        public async Task AddAsync(Product model)
        {
            model.CreatedTime = DateTime.Now;
            model.StatusFlag = true;

            await _productCollection.InsertOneAsync(model);
        }

        public async Task UpdateAsync(Product model) => 
            await _productCollection.FindOneAndReplaceAsync(product => product.ProductID == model.ProductID, model);

        public async Task DeleteAsync(string productId) => 
            await _productCollection.DeleteOneAsync(product => product.ProductID == productId);
    }
}
