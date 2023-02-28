using CourseApplication.Data.Entities;
using CourseApplication.Models.ValueTypeModel;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories
{
    public interface IValueTypeRepository
    {
        public Task<List<ValueTypeDisplayModel>> GetAllTypes();
        public Task<string> GetValueIdByName(string name);
    }
}
