using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Services
{
    public interface ICustomFieldService
    {
        public Task AddCustomField(List<CustomFieldsCreateModel> model, string collectionId);
        public Task<List<CustomFieldsDisplayModel>> GetCustomFieldsForCollection(string collectionId);
        public Task EditFields(List<CustomFieldsEditModel> models, string collectionId);

    }
}
