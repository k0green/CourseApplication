using CourseApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Data.Entities
{
    [Keyless]
    public class ItemTag
    {
        public string ItemId { get; set; }
        public string TagId { get; set; }

        public Item? Item { get; set; }
        public Tag? Tag { get; set; }
    }
}
