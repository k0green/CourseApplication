using System.ComponentModel.DataAnnotations;

namespace CourseApplication.Models.CustomFieldModels
{
    public class CustomFieldsEditModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Field must be filled")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "String length must be from 1 to 30 symbols")]
        public string FieldName { get; set; }
        public string ValueTypeId { get; set; }
        public string? CollectionId { get; set; }
        public string? EditStatus { get; set; }
    }
}
