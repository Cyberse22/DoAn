using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface IBlogRepository
    {
        public Task<List<BlogModel>> GetAllBlogsAsync();
        public Task<BlogModel> GetBlogByIdAsync(int id);
        public Task<BlogModel> GetBlogByNameAsync(string name);
        public Task<BlogModel> GetBlogBySlugAsync(string slug);
        public Task<int> AddBlogAsync(BlogModel model);
        public Task UpdateBlogAsync(int id, BlogModel model);
        public Task DeleteBlogAsync(int id);

    }
}
