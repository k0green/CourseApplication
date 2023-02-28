using CourseApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Data.Entities
{
    [Keyless]
    public class UserCollection
    {
        public string UserId { get; set; }
        public string CollectionId { get; set; }

        public Collection? Collection { get; set; }
        public User? User { get; set; }
    }
}
