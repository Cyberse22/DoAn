using DoAnBackend.Data;
using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface IBlogRepository
    {
        public Task<List<BlogModel>> getAllBlogsAsync();
        public Task<BlogModel> getBlogByIdAsync(int id);
        public Task<int> addBlogAsync(BlogModel model);
        public Task updateBlogAsync(int id, BlogModel model);
        public Task<int> deleteBlogAsync(int id);

    }
}
