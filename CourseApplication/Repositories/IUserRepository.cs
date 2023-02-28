using CourseApplication.Entities;
using CourseApplication.Models;

namespace CourseApplication.Repositories
{
    public interface IUserRepository
    {
        public Task<string> GetIdByName(string name);
        public Task<List<User>> GetAllUsers();
        public Task<List<UserDisplayModel>> GetAllUsersDisplayModel();
        public Task ChangeStatus(string id, string newStatus);
        public Task ChangeRole(string id, string newRole);
        public Task DeleteUser(string id);
    }
}
