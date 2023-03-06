using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.ItemModel;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class ItemServiceImpl : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICustomFieldValueService _valueService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public ItemServiceImpl(IItemRepository ItemRepository,
            ICustomFieldValueService valueService,
            ITagService tagService,
            IMapper mapper)
        {
            _itemRepository = ItemRepository;
            _tagService = tagService;
            _valueService = valueService;
            _mapper = mapper;
        }
        public async Task<List<ItemsDisplayModel>> GetAllItems() => await _itemRepository.GetAllItems();
        public async Task<List<ItemsDisplayModel>> GetNewItems(int skipAmount) => await _itemRepository.GetNewItems(skipAmount);

        public async Task<ItemsDisplayModel> GetItemAsync(string id)
        {
            var itemEntity = await _itemRepository.GetItemAsync(id);
            var itemDemo = _mapper.Map<ItemsDisplayModel>(itemEntity);
            return itemDemo;
        }
        
        public async Task Create(CreateItemModel createItem)
        {
            var item = _mapper.Map<Item>(createItem);
            item.Id = Guid.NewGuid().ToString();
            item.CreateTime = DateTime.Now;
            await _itemRepository.Create(item);
            if(createItem.TagsName!=null)
                await _tagService.Create(createItem.TagsName, item.Id);
            var values = _mapper.Map<List<CustomFieldsValues>>(createItem.CustomFields);
            if(values!=null)
                await _valueService.Add(values, item.Id);
        }

        public async Task<List<ItemsDisplayModel>> GetAllItemByTagId(string tagId)
            => await _itemRepository.GetAllItemByTagId(tagId);

        public async Task Edit(EditItemModel item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            if(item.Values!=null)
             await _valueService.EditFields(item.Values, item.Id);
            if(item.TagsName!=null)
                await _tagService.EditItemsTag(item.TagsName, item.Id);
            await _itemRepository.Edit(itemEntity);
        }
        public async Task<List<ItemsDisplayModel>> GetCollectionsItems(string id) => await _itemRepository.GetCollectionsItems(id);
        public async Task Delete(string id)
        {
            var item = await _itemRepository.GetItemAsync(id);
            await _valueService.DeleteAllValuesForItemsAsync(id);
            await _itemRepository.Delete(item); 
        }

        public async Task<EditItemModel> GetItemForEdit(string id)
        {
            var item = await _itemRepository.GetItemForEdit(id);
            item.Values = await _valueService.GetFieldsForItemAsync(id);
            item.TagsName = await _tagService.GetAllTagsForItemByIdAsync(id);
            return item;
        }
        public async Task<GetFieldsNameModel> GetItemForCreate(string id) => await _itemRepository.GetItemForCreate(id);

        public async Task<List<ItemsDisplayModel>> GetItemsForCollection(string collectionId, string type, string value)
        {
            var items = await _itemRepository.GetCollectionsItems(collectionId);
            if (type == "findName")
                items = await FilterByPartOfNameAsync(items, value);
            else if (type == "findDay")
                items = await FilterByCreateDayAsync(items, value);
            else if (type == "sort")
                items = await SortItemsByTypeAsync(items, value);
            else if (type == "reverse")
                items = await ReverseItemsListAsync(items);
            return items;
        }

        public async Task<List<ItemsDisplayModel>> SortItemsByTypeAsync(List<ItemsDisplayModel> items, string type)
        {
            switch (type)
            {
                case "name":
                    items = items.OrderBy(x => x.Name).ToList();
                    break;
                case "time":
                    items = items.OrderBy(x => x.CreateTime).ToList();
                    break;
            }
            return items;
        }
        
        public async Task<List<ItemsDisplayModel>> ReverseItemsListAsync(IEnumerable<ItemsDisplayModel> models)
        {
            return models.Reverse().ToList();
        }
        
        public async Task<List<ItemsDisplayModel>> FilterByCreateDayAsync(List<ItemsDisplayModel> models, string date)
        {
            var d = DateTime.Parse(date).ToShortDateString();
            return models.Where(x => x.CreateTime.ToShortDateString().Contains(d)).ToList();
        }
        
        public async Task<List<ItemsDisplayModel>> FilterByPartOfNameAsync(List<ItemsDisplayModel> models, string part)
        {
            return models.Where(x => x.Name.Contains(part)).ToList();
        }
    }
}
