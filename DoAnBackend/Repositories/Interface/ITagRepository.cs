using DoAnBackend.Models;

namespace DoAnBackend.Repositories.Interface
{
    public interface ITagRepository
    {
        public Task<List<TagModel>> getAllTagAsync();
        public Task<TagModel> GetTagByNameAsync(string name);
        public Task<string> AddTagAsync(TagModel tag);
        public Task DeleteCategory(string Name);
    }
}
