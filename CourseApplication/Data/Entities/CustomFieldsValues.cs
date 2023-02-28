namespace CourseApplication.Data.Entities;

public class CustomFieldsValues
{
    public string Id { get; set; }
    public string? Value { get; set; }
    public string ItemId { get; set; }
    public string CustomFieldId { get; set; }
    public CustomField? CustomField { get; set; }
    public Item? Item { get; set; }
}