using CourseApplication.Entities;
using CourseApplication.Models;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        IUserRepository _userRepository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GetIdByName(string name) => await _userRepository.GetIdByName(name);
        public async Task<List<User>> GetAllUser() => await _userRepository.GetAllUsers();

        public async Task<List<UserDisplayModel>> GetAllUsersDisplayModel() => await _userRepository.GetAllUsersDisplayModel();

        public async Task ChangeStatus(string id, string newStatus) => await _userRepository.ChangeStatus(id, newStatus);
        public async Task ChangeRole(string id, string newRole) => await _userRepository.ChangeRole(id, newRole);

        public async Task DeleteUser(string id) => await _userRepository.DeleteUser(id);
    }
}
