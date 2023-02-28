using CourseApplication.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseApplication.Data.Entities
{
    public class Theme
    {
        public Theme()
        {
            Collections = new HashSet<Collection>();
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Collection> Collections { get; set; }
    }
}
