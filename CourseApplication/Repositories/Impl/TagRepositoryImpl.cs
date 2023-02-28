using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.TagModels;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl
{
    public class TagRepositoryImpl : ITagRepository
    {
        private ApplicationDbContext _dbContext;

        public TagRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<List<TagsDisplayModel>> GetAllTagsAsync()
        {
            var tags = await _dbContext.Tag.Select(x=>new TagsDisplayModel
            {
                Id= x.Id,
                Name= x.Name,
            }).ToListAsync();
            return tags;
        }
        
        public async Task<TagsDisplayModel> GetTagByIdAsync(string id)
        {
            var tag = await _dbContext.Tag.Select(x=>new TagsDisplayModel
            {
                Id= x.Id,
                Name= x.Name,
            }).FirstAsync(x=>x.Id==id);
            return tag;
        }
        
        public async Task<TagsDisplayModel> GetTagByNameAsync(string name)
        {
            var tag = await _dbContext.Tag.Select(x=>new TagsDisplayModel
            {
                Id= x.Id,
                Name= x.Name,
            }).FirstOrDefaultAsync(x=>x.Name==name);
            return tag;
        }

        public async Task Create(Tag tag)
        {
            await _dbContext.Tag.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
        }
    }
}
