using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Models.CustomFieldValueModels;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Services
{
    public interface ICustomFieldValueService
    {
        public Task<List<CustomFieldValueDisplayModel>> GetFieldsForItemAsync(string itemId);
        public Task<List<CustomFieldValueDisplayModel>> GetCustomFieldsForCollection(string itemId);
        public Task Add(List<CustomFieldsValues> models, string itemId);
        public Task EditFields(List<CustomFieldValueDisplayModel> models, string itemId);
        public Task DeleteAllValuesForItemsAsync(string itemId);

    }
}
