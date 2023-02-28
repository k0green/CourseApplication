using CourseApplication.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseApplication.Data.Entities
{
    public class Tag
    {
        public Tag()
        {
            ItemTags = new HashSet<ItemTag>();
        }
        
        public Tag(string id, string name)
        {
            ItemTags = new HashSet<ItemTag>();
            Id = id;
            Name = name;
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<ItemTag> ItemTags { get; set; }
    }
}
