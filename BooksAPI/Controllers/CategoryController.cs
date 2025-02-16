using BusinessLogicLayer.IServices;
using DTOs.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryDto addCategoryDto)
        {
            await _categoryService.AddCategoryAsync(addCategoryDto);
            return Ok("Added !");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCateogryDto updateCateogryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCateogryDto);
            return Ok("Updated !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Deleted !");
        }
    }
}
