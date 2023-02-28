using CourseApplication.Entities;

namespace CourseApplication.Data.Entities;

public class UserStatus
{
    
    public UserStatus()
    {
        Users = new HashSet<User>();
    }
    
    
    public string Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<User> Users { get; set; }
}