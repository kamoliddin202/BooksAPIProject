using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.CategoryDtos;

namespace BusinessLogicLayer.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(AddCategoryDto categoryDto);
        Task UpdateCategoryAsync(UpdateCateogryDto updateCateogryDto);
        Task DeleteCategoryAsync(int id);
    }
}
