using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldValueModels;

namespace CourseApplication.Models.ItemModel
{
    public class ItemsDisplayModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string CollectionId { get; set; }
        public List<CustomFieldValueDisplayModel> Values { get; set; }
    }
}
