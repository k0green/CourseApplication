namespace CourseApplication.Models.CustomFieldModels
{
    public class CustomFieldsCreateModel
    {
        public string FieldName { get; set; }
        public string? ValueTypeId { get; set; }
        public string? CollectionId { get; set; }
    }
}
