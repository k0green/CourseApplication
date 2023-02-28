using System.Data;

namespace CourseApplication.Data.Entities
{
    public class CustomField
    {
        public CustomField()
        {
            CustomFieldsValues = new HashSet<CustomFieldsValues>();
        }
        public string Id { get; set; }
        public string FieldName { get; set; }
        public string ValueTypeId { get; set; }
        public string CollectionId { get; set; }

        public virtual ValueType? ValueType { get; set; }
        public virtual Collection? Collection { get; set; }
        public ICollection<CustomFieldsValues> CustomFieldsValues { get; set; }
    }
}
