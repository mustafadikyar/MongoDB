using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet] public async Task<IActionResult> GetAllAsync() => Ok(await _productService.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(string id) => Ok(await _productService.GetByIdAsync(id));
        [HttpPost] public async Task AddAsync(Product model) => await _productService.AddAsync(model);
        [HttpPut] public async Task UpdateAsync(Product model) => await _productService.UpdateAsync(model);
        [HttpDelete] public async Task DeleteAsync(string id) => await _productService.DeleteAsync(id);
    }
}
