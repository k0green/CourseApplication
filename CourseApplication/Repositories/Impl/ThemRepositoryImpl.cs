using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl
{
    public class ThemRepositoryImpl : IThemRepository
    {
        private ApplicationDbContext _dbContext;

        public ThemRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<List<Theme>> GetAllThems() => await _dbContext.Theme.ToListAsync();

        public async Task<string> GetThemIdByName(string name)
        {
            var theme = await _dbContext.Theme.FirstOrDefaultAsync(x=>x.Name==name);
            return theme.Id.ToString();
        }


    }
}
