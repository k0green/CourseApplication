using CourseApplication.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseApplication.Data.Entities
{
    public class Collection
    {
        public Collection()
        {
            Items = new HashSet<Item>();
            UserCollections = new HashSet<UserCollection>();
            CustomFields = new HashSet<CustomField>();
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThemeId { get; set; }
        public string? PhotoUrl { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<UserCollection> UserCollections { get; set; }
        public ICollection<CustomField> CustomFields { get; set; }
        public Theme? Them { get; set; }
    }

}
