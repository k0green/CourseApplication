using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.ValueTypeModel;
using CourseApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl
{
    public class ValueTypeRepositoryImpl : IValueTypeRepository
    {
        private ApplicationDbContext _dbContext;

        public ValueTypeRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<List<ValueTypeDisplayModel>> GetAllTypes()
        {
            var types = await _dbContext.ValueType.Select(x=>new ValueTypeDisplayModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return types;
        }

        public async Task<string> GetValueIdByName(string name)
        {
            var value = await _dbContext.ValueType.FirstOrDefaultAsync(x => x.Name == name);
            return value.Id;
        }
    }
}
