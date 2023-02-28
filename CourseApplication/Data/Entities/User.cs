using CourseApplication.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApplication.Entities;

public class User : IdentityUser
{
    public User()
    {
        UserCollections = new HashSet<UserCollection>();
        UserItemLikes = new HashSet<UserItemLike>();
        UserItemComments = new HashSet<UserItemComment>();
    }

    public string StatusId { get; set; }


    public ICollection<UserCollection> UserCollections { get; set; }
    public ICollection<UserItemLike> UserItemLikes { get; set; }
    public ICollection<UserItemComment> UserItemComments { get; set; }
    public UserStatus? Status { get; set; }
}