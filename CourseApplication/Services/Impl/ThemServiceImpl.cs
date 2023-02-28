using CourseApplication.Data.Entities;
using CourseApplication.Entities;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class ThemServiceImpl : IThemService
    {
        IThemRepository _themRepository;

        public ThemServiceImpl(IThemRepository themRepository)
        {
            _themRepository = themRepository;
        }
        public async Task<List<Theme>> GetAllThems() => await _themRepository.GetAllThems();
        public async Task<string> GetThemIdByName(string name) => await _themRepository.GetThemIdByName(name);
    }
}
