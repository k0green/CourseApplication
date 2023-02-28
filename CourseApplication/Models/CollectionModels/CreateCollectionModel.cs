using System.ComponentModel.DataAnnotations;
using CourseApplication.Models.CustomFieldModels;

namespace CourseApplication.Models.CollectionModels
{
    public class CreateCollectionModel
    {
        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "String length must be from 1 to 30 symbols")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "String length must be from 1 to 100 symbols")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field must be filled")]
        public string ThemeId { get; set; }
        public string CreatorId { get; set; }
        public string? PhotoUrl { get; set; }
        public List<CustomFieldsCreateModel>? CustomFields { get; set; }
    }
}
