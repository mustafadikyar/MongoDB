using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category model);
        Task<Category> GetByIdAsync(string id);
    }
}
