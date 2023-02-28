using CourseApplication.Data.Entities;
using CourseApplication.Entities;
using CourseApplication.Models.ValueTypeModel;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class ValueTypeServiceImpl : IValueTypeService
    {
        IValueTypeRepository _typeRepository;

        public ValueTypeServiceImpl(IValueTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<List<ValueTypeDisplayModel>> GetAllTypes() => await _typeRepository.GetAllTypes();
    }
}
