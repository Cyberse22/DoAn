using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> getAllCategoryAsync();
        public Task<CategoryModel> getCategoryByIdAsync(int id);
        public Task<int> AddCategoryAsync(CategoryModel categoryModel);
        public Task UpdateCategoryAsync(int id, CategoryModel categoryModel);
        public Task DeleteCategoryAsync(int id);
    }
}
