using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using DoAnBackend.Services.Interface;

namespace DoAnBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> AddCategoryAsync(CategoryModel categoryModel)
        {
            return _categoryRepository.AddCategoryAsync(categoryModel);
        }

        public Task DeleteCategoryAsync(int id)
        {
            return _categoryRepository.DeleteCategoryAsync(id);
        }

        public Task<List<CategoryModel>> getAllCategoryAsync()
        {
            return _categoryRepository.getAllCategoryAsync();
        }

        public Task<CategoryModel> getCategoryByIdAsync(int id)
        {
            return _categoryRepository.getCategoryByIdAsync(id);
        }

        public Task UpdateCategoryAsync(int id, CategoryModel categoryModel)
        {
            return _categoryRepository.UpdateCategoryAsync(id, categoryModel);
        }
    }
}
