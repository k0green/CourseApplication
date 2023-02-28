using CourseApplication.Data.Entities;
using CourseApplication.Models.ValueTypeModel;

namespace CourseApplication.Services
{
    public interface IValueTypeService
    {
        public Task<List<ValueTypeDisplayModel>> GetAllTypes();
    }
}
