using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Configurations;
using WebApi.Models;

namespace WebApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        public CategoryService(IDatabaseSettings databaseSettings)
        {
            MongoClient client = new(databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<List<Category>> GetAllAsync() => 
            await _categoryCollection.Find(category => true).ToListAsync();

        public async Task AddAsync(Category model)
        {
            model.CreatedTime = DateTime.Now;
            model.StatusFlag = true;
            await _categoryCollection.InsertOneAsync(model);
        }

        public async Task<Category> GetByIdAsync(string id) => 
            await _categoryCollection.Find<Category>(category => category.CategoryId == id).FirstOrDefaultAsync();
    }
}
