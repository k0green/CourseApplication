using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Models.TagModels;
using CourseApplication.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CourseApplication.Repositories.Impl
{
    public class ItemRepositoryImpl : IItemRepository
    {
        private ApplicationDbContext _dbContext;

        public ItemRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var item = await _dbContext.Item.FirstAsync(x => x.Id == id);
            return item;
        }
        
        public async Task<List<ItemsDisplayModel>> GetAllItems()
        {
            var items = await _dbContext.Item.Select(x=>new ItemsDisplayModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreateTime = x.CreateTime,
                CollectionId = x.CollectionId
            }).ToListAsync();
            return items;
        }
        
        public async Task<List<ItemsDisplayModel>> GetNewItems(int skipAmount)
        {
            var items = await _dbContext.Item.Skip(skipAmount).Take(20).Select(x=>new ItemsDisplayModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreateTime = x.CreateTime,
                CollectionId = x.CollectionId
            }).OrderBy(x => x.CreateTime).ToListAsync();
            return items;
        }

        public async Task<List<ItemsDisplayModel>> GetAllItemByTagId(string tagId)
        {
            var items = await _dbContext.ItemTag.Where(x => x.TagId == tagId)
                .Select(x => new ItemsDisplayModel()
                {
                    Id = x.ItemId,
                    Name = x.Item.Name,
                    CreateTime = x.Item.CreateTime,
                    CollectionId = x.Item.CollectionId
                }).ToListAsync();
            return items;
        }
        
        public async Task<GetFieldsNameModel> GetItemForCreate(string id)
        {
            var names = await _dbContext.Collection.Select(x => new GetFieldsNameModel
            {
                CollectionId = x.Id,
            }).FirstOrDefaultAsync(x => x.CollectionId == id);
            return names;
        }


        public async Task<EditItemModel> GetItemForEdit(string id)
        {
            var item = await _dbContext.Item.Select(x => new EditItemModel
            {
                Id = x.Id,
                Name = x.Name,
                CreateTime = x.CreateTime,
                CollectionId= x.CollectionId
            }).FirstOrDefaultAsync(c => c.Id == id);
            return item;
        }

        public async Task<List<ItemsDisplayModel>> GetCollectionsItems(string id)
        {
            var items = await _dbContext.Item.
                Where(x => x.CollectionId == id).
                Select(x => new ItemsDisplayModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreateTime = x.CreateTime,
                    CollectionId = id
                }).ToListAsync();
            return items;
        }

        public async Task Delete(Item item)
        {
            _dbContext.Item.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(Item item)
        {
            if (item != null)
            {
                _dbContext.Update(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Create(Item item)
        {
            if (item != null)
            {
                await _dbContext.Item.AddAsync(item);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
