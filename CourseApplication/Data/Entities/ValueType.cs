using CourseApplication.Entities;

namespace CourseApplication.Data.Entities
{
    public class ValueType
    {
        public ValueType()
        {
            CustomFields = new HashSet<CustomField>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomField> CustomFields { get; set; }

    }
}
