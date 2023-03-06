using System.ComponentModel.DataAnnotations;
using CourseApplication.Models.CustomFieldValueModels;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Models.ItemModel
{
    public class EditItemModel
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "String length must be from 1 to 30 symbols")]
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public List<CustomFieldValueDisplayModel>? Values { get; set; }
        public List<TagsDisplayModel>? TagsName { get; set; }
        public string CollectionId { get; set; }
    }
}
