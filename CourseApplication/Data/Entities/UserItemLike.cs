using CourseApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Data.Entities
{
    [Keyless]
    public class UserItemLike
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }

        public Item? Item { get; set; }
        public User? User { get; set; }
    }
}
