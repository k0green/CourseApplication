using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Repositories
{
    public interface ITagRepository
    {
        public Task<List<TagsDisplayModel>> GetAllTagsAsync();
        public Task<TagsDisplayModel> GetTagByNameAsync(string name);
        public Task<TagsDisplayModel> GetTagByIdAsync(string id);
        public Task Create(Tag tag);
    }
}
