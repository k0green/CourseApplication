using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldModels;

namespace CourseApplication.Repositories;

public interface ICustomFieldRepository
{
    public Task<CustomField> GetCustomFieldByIdAsync(string fieldId);
    public Task AddCustomField(CustomField field, string collectionId);
    public Task<List<CustomFieldsDisplayModel>> GetCustomFieldsForCollection(string collectionId);
    public Task Edit(CustomField field);
    public Task Delete(CustomField field);
}