using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DoAnBackend.Models;
using DoAnBackend.Data;
using DoAnBackend.Repositories.Interface;

namespace DoAnBackend.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlogRepository(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> addBlogAsync(BlogModel model)
        {
            await _context.SaveChangesAsync();
            return 0;
        }

        public Task<int> deleteBlogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BlogModel>> getAllBlogsAsync()
        {
            var blogs = await _context.Blogs!.ToListAsync();
            return _mapper.Map<List<BlogModel>>(blogs);
        }

        public async Task<BlogModel> getBlogByIdAsync(int id)
        {
            var blog = await _context.Blogs!.FindAsync(id);
            return _mapper.Map<BlogModel>(blog);
        }

        public Task updateBlogAsync(int id, BlogModel model)
        {
            throw new NotImplementedException();
        }
    }
}
