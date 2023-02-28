using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Services
{
    public interface ITagService
    {
        public Task<List<TagsDisplayModel>> GetAllTags();
        public Task<List<TagsDisplayModel>> GetTHeMostPopularTags();
        public Task CreateConnect(string itemId, string tagId);
        public Task Create(List<string> tagsNames, string itemId);
        public Task<List<TagsDisplayModel>> GetAllTagsForItemByIdAsync(string itemId);
        public Task EditItemsTag(List<TagsDisplayModel> tagsName, string itemId);
        public Task DeleteConnection(string itemId, string tagId);

    }
}
