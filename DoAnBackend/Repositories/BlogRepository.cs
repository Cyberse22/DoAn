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

        public Task<int> AddBlogAsync(BlogModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBlogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogModel>> GetAllBlogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogModel> GetBlogByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogModel> GetBlogByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<BlogModel> GetBlogBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBlogAsync(int id, BlogModel model)
        {
            throw new NotImplementedException();
        }
    }
}
