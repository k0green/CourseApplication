using CourseApplication.Data.Entities;

namespace CourseApplication.Repositories
{
    public interface IThemRepository
    {
        public Task<List<Theme>> GetAllThems();
        public Task<string> GetThemIdByName(string name);
    }
}
