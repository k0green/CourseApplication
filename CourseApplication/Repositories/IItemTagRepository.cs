using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Models.ItemTagModels;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Repositories
{
    public interface IItemTagRepository
    {
        public Task<List<ItemTagsDisplayModel>> GetAllItemTags();
        public Task Create(ItemTag itemTag);
        public Task<List<TagsDisplayModel>> GetAllTagsForItemByIdAsync(string itemId);
        public Task<ItemTag> GetItemTagAsync(string itemId, string tagId);
        public Task Delete(ItemTag itemTag);
    }
    
}
