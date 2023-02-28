using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Models.CustomFieldValueModels;

namespace CourseApplication.Repositories;

public interface ICustomFieldsValuesRepository
{
    public Task<List<CustomFieldValueDisplayModel>> GetFieldsForItemAsync(string itemId);
    public Task Add(CustomFieldsValues field);
    public Task<List<CustomFieldValueDisplayModel>> GetCustomFieldsForItem(string itemId);
    public Task Edit(CustomFieldsValues field);
    public Task Delete(CustomFieldsValues field);
    public Task<List<CustomFieldsValues>> GetValuesByItemIdAsync(string itemId);
}