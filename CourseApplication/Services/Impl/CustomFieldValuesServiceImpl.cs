using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldValueModels;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class CustomFieldValueServiceImpl : ICustomFieldValueService
    {
        private ICustomFieldsValuesRepository _valuesRepository;
        private readonly IMapper _mapper;

        public CustomFieldValueServiceImpl(ICustomFieldsValuesRepository valuesRepository,
            IMapper mapper)
        {
            _valuesRepository = valuesRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomFieldValueDisplayModel>> GetCustomFieldsForCollection(string itemId) =>
            await _valuesRepository.GetCustomFieldsForItem(itemId);

        public async Task<List<CustomFieldValueDisplayModel>> GetFieldsForItemAsync(string itemId) =>
            await _valuesRepository.GetFieldsForItemAsync(itemId);
        
        public async Task Add(List<CustomFieldsValues> models, string itemId)
        {
            foreach (var model in models)
            {
                model.ItemId = itemId;
                await _valuesRepository.Add(model);
            }
        }
        
        public async Task EditFields(List<CustomFieldValueDisplayModel> models, string itemId)////////////////
        {
            foreach (var model in models)
            {
                var field = _mapper.Map<CustomFieldsValues>(model);
                field.ItemId = itemId;
                await _valuesRepository.Edit(field);
            }
        }

        public async Task DeleteAllValuesForItemsAsync(string itemId)
        {
            var values = await _valuesRepository.GetValuesByItemIdAsync(itemId);
            foreach (var item in values)
            {
                await _valuesRepository.Delete(item);
            }
        }

    }
}
