using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.TagModels;
using Microsoft.EntityFrameworkCore;
using CourseApplication.Models.ItemTagModels;

namespace CourseApplication.Repositories.Impl
{
    public class ItemTagRepositoryImpl : IItemTagRepository
    {
        private ApplicationDbContext _dbContext;

        public ItemTagRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<List<ItemTagsDisplayModel>> GetAllItemTags()
        {
            var tags = await _dbContext.ItemTag.Select(x=>new ItemTagsDisplayModel()
            {
                ItemId= x.ItemId,
                TagId= x.TagId,
            }).ToListAsync();
            return tags;
        }
        
        public async Task Create(ItemTag itemTag)
        {
            await _dbContext.ItemTag.AddAsync(itemTag);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<ItemTag> GetItemTagAsync(string itemId, string tagId)
        {
            var tag = await _dbContext.ItemTag.FirstAsync(x => x.ItemId == itemId && x.TagId == tagId);
            return tag;
        }

        public async Task Delete(ItemTag itemTag)
        {
            _dbContext.ItemTag.Remove(itemTag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TagsDisplayModel>> GetAllTagsForItemByIdAsync(string itemId)
        {
            var tags = await _dbContext.ItemTag.
                Where(x => x.ItemId == itemId).
                Select(x => new TagsDisplayModel
                {
                    Id = x.TagId,
                    Name = x.Tag.Name
                }).ToListAsync();
            return tags;
        }
    }
}
