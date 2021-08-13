using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpGet] public async Task<IActionResult> GetAllAsync() => Ok(await _categoryService.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(string id) => Ok(await _categoryService.GetByIdAsync(id));
        [HttpPost] public async Task AddAsync(Category model) => await _categoryService.AddAsync(model);
    }
}
