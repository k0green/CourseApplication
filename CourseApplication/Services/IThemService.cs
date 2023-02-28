using CourseApplication.Data.Entities;

namespace CourseApplication.Services
{
    public interface IThemService
    {
        public Task<List<Theme>> GetAllThems();
        public Task<string> GetThemIdByName(string name);
    }
}
