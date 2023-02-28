using CourseApplication.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CourseApplication.Data.Entities
{
    public class Item
    {
        public Item()
        {
            ItemTags = new HashSet<ItemTag>();
            UserItemLikes = new HashSet<UserItemLike>();
            UserItemComments = new HashSet<UserItemComment>();
            CustomFieldsValues = new HashSet<CustomFieldsValues>();
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string CollectionId { get; set; }

        public virtual Collection? Collection { get; set; }
        public ICollection<ItemTag> ItemTags { get; set; }
        public ICollection<UserItemLike> UserItemLikes { get; set; }
        public ICollection<UserItemComment> UserItemComments { get; set; }
        public ICollection<CustomFieldsValues> CustomFieldsValues { get; set; }
    }
}
