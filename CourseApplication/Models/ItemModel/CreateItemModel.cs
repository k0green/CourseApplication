using System.ComponentModel.DataAnnotations;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Models.TagModels;

namespace CourseApplication.Models.ItemModel
{
    public class CreateItemModel
    {
        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "String length must be from 1 to 30 symbols")]
        public string Name { get; set; }
        public List<CustomFieldsDisplayModel> CustomFields { get; set; }
        public List<string>? TagsName { get; set; }
        public string CollectionId { get; set; }
    }
}
