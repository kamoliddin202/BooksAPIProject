using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.CategoryDtos;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddCategoryAsync(AddCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.categoryInterface.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.categoryInterface.GetByIdAsync(id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            await _unitOfWork.categoryInterface.DeleteAsync(category.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.categoryInterface.GetAllAsync();
            return categories.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.categoryInterface.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCateogryDto updateCateogryDto)
        {
            var category = await _unitOfWork.categoryInterface.GetByIdAsync(updateCateogryDto.Id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(updateCateogryDto));
            }

            _mapper.Map(updateCateogryDto, category);
            await _unitOfWork.categoryInterface.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
