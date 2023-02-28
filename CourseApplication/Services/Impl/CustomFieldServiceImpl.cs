using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class CustomFieldServiceImpl : ICustomFieldService
    {
        private ICustomFieldRepository _customFieldRepository;
        private readonly IMapper _mapper;

        public CustomFieldServiceImpl(ICustomFieldRepository customFieldRepository,
            IMapper mapper)
        {
            _customFieldRepository = customFieldRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomFieldsDisplayModel>> GetCustomFieldsForCollection(string collectionId) =>
            await _customFieldRepository.GetCustomFieldsForCollection(collectionId);

        public async Task AddCustomField(List<CustomFieldsCreateModel> models, string collectionId)
        {
            foreach (var model in models)
            {
                var fields = _mapper.Map<CustomField>(model);
                await _customFieldRepository.AddCustomField(fields, collectionId);
            }
        }

        public async Task EditFields(List<CustomFieldsEditModel> models, string collectionId)////////////////
        {
            foreach (var model in models)
            {
                var field = _mapper.Map<CustomField>(model);
                switch (model.EditStatus)
                {
                    case "update":
                        await _customFieldRepository.Edit(field);
                        break;
                    case "delete":
                        await _customFieldRepository.Delete(field);
                        break;
                    case "add":
                        await _customFieldRepository.AddCustomField(field, collectionId);
                        break;
                }
            }
        }

    }
}
