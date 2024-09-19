using AutoMapper;
using DoAnBackend.Data;
using DoAnBackend.Models;
using DoAnBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DoAnBackend.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryModel categoryModel)
        {
            var newCategory = _mapper.Map<Category>(categoryModel);
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.Id; 
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var deleteCategory = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (deleteCategory != null) 
            {
                _context.Categories.Remove(deleteCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryModel>> getAllCategoryAsync()
        {
            var categories = await _context.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> getCategoryByIdAsync(int id)
        {
            var category = await _context.Categories!.FindAsync(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task UpdateCategoryAsync(int id, CategoryModel categoryModel)
        {
            if (id == categoryModel.Id)
            {
                var updateCategory = _mapper.Map<Category>(categoryModel);
                _context.Categories!.Update(updateCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}