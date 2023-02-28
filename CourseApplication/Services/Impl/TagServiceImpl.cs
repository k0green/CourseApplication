using CourseApplication.Data.Entities;
using CourseApplication.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Models.TagModels;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class TagServiceImpl : ITagService
    {
        ITagRepository _tagRepository;
        private readonly IItemTagRepository _itemTagRepository;

        public TagServiceImpl(ITagRepository tagRepository,
            IItemTagRepository itemTagRepository)
        {
            _tagRepository = tagRepository;
            _itemTagRepository = itemTagRepository;
        }

        public async Task<List<TagsDisplayModel>> GetAllTags() => await _tagRepository.GetAllTagsAsync();

        public async Task<List<TagsDisplayModel>> GetTHeMostPopularTags()
        {
            var tags = new List<TagsDisplayModel>();
            var itemTag = await _itemTagRepository.GetAllItemTags();
            var q = itemTag.GroupBy(x => x.TagId)
                .Select(g => new {Value = g.Key, Count = g.Count()})
                .OrderByDescending(x=>x.Count);
            foreach (var x in q)
            {
                var tag = await _tagRepository.GetTagByIdAsync(x.Value);
                tags.Add(tag);
            }

            return tags.Take(10).ToList();
        }

        public async Task Create(List<string> tagsNames, string itemId)
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            foreach (var item in tagsNames)
            {
                if (tags.Exists(x => x.Name == item))
                {
                    var oldTag = tags.First(x => x.Name == item);
                    await CreateConnect(itemId, oldTag.Id);
                }
                else
                {
                    var tag = new Tag(Guid.NewGuid().ToString(), item);
                    await _tagRepository.Create(tag);
                    await CreateConnect(itemId, tag.Id);
                }
            }
        }

        public async Task CreateConnect(string itemId, string tagId)
        {
            var itemTag = new ItemTag()
            {
                ItemId = itemId,
                TagId = tagId
            };
            await _itemTagRepository.Create(itemTag);
        }
        
        public async Task DeleteConnection(string itemId, string tagId)
        {
            var itemTag = await _itemTagRepository.GetItemTagAsync(itemId, tagId);
            await _itemTagRepository.Delete(itemTag);
        }

        public async Task<List<TagsDisplayModel>> GetAllTagsForItemByIdAsync(string itemId) =>
            await _itemTagRepository.GetAllTagsForItemByIdAsync(itemId);

        public async Task CheckItemsTagAsync(TagsDisplayModel tagsDisplayModel, string itemId)
        {
            var check = await _tagRepository.GetTagByNameAsync(tagsDisplayModel.Name);
            if (check==null)
            {
                var tag = new Tag(Guid.NewGuid().ToString(), tagsDisplayModel.Name);
                await _tagRepository.Create(tag);
                await CreateConnect(itemId, tag.Id);
            }
            else await CreateConnect(itemId, check.Id);
        }
        
        public async Task EditItemsTag(List<TagsDisplayModel> tagsName, string itemId)
        {
            foreach (var item in tagsName)
            {
                if (item.Name == "d254l" && item.Id!=null)
                    await DeleteConnection(itemId, item.Id);
                if (item.Id == null && item.Name != "d254l")
                {
                    await CheckItemsTagAsync(item, itemId);
                }
            }
        }
    }
}
