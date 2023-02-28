using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;

namespace CourseApplication.Repositories
{
    public interface IItemRepository
    {
        public Task<Item> GetItemAsync(string id);
        public Task<List<ItemsDisplayModel>> GetNewItems(int skipAmount);
        public Task<List<ItemsDisplayModel>> GetAllItems();
        public Task<List<ItemsDisplayModel>> GetAllItemByTagId(string tagId);
        public Task Create(Item item);
        public Task Edit(Item item);
        public Task Delete(Item item);
        public Task<List<ItemsDisplayModel>> GetCollectionsItems(string id);
        public Task<EditItemModel> GetItemForEdit(string id);
        public Task<GetFieldsNameModel> GetItemForCreate(string id);
    }
}
