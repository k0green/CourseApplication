namespace CourseApplication.Models.CustomFieldValueModels;

public class CustomFieldValueDisplayModel
{
    public string Id { get; set; }
    public string? Value { get; set; }
    public string ItemId { get; set; }
    public string CustomFieldId { get; set; }
    public string FieldName { get; set; }
    public string ValueTypeId { get; set; }
    public string CollectionId { get; set; }
}