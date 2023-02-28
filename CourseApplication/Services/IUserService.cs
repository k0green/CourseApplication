using CourseApplication.Entities;
using CourseApplication.Models;

namespace CourseApplication.Services
{
    public interface IUserService
    {
        public Task<string> GetIdByName(string name);
        public Task<List<User>> GetAllUser();
        public Task<List<UserDisplayModel>> GetAllUsersDisplayModel();
        public Task ChangeStatus(string id, string newStatus);
        public Task ChangeRole(string id, string newRole);
        public Task DeleteUser(string id);
    }
}
