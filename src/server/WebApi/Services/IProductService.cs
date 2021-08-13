using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task AddAsync(Product model);
        Task UpdateAsync(Product model);
        Task DeleteAsync(string productId);
    }
}
