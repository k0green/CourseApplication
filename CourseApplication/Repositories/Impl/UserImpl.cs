using CourseApplication.Data;
using CourseApplication.Entities;
using CourseApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl;

public class UserImpl : IUserRepository
{
    private ApplicationDbContext _dbContext;
    UserManager<User> _userManager;

    public UserImpl(UserManager<User> userManager, ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
        _userManager = userManager;
    }

    public async Task<string> GetIdByName(string name)
    {
        var user = await _userManager.FindByNameAsync(name);
        return user.Id;
    }

    public async Task<List<User>> GetAllUsers() => _userManager.Users.ToList();

    public async Task<List<UserDisplayModel>> GetAllUsersDisplayModel()
    {
        var userDisplayModels = await _userManager.Users.Select(x => new UserDisplayModel
        {
            Id = x.Id,
            Name = x.UserName,
            Email = x.Email,
            Status = x.Status.Name.Trim()
        }).ToListAsync();
        foreach (var item in userDisplayModels)
        {
            var userRole = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(item.Id));
            item.Role = userRole.First();
        }
        return userDisplayModels;
    }
    
    public async Task ChangeStatus(string id, string newStatus)
    {
        var user = await _userManager.FindByIdAsync(id);
        var status = await _dbContext.UserStatus.FirstOrDefaultAsync(x => x.Name == newStatus);
        user.StatusId = status.Id;
        _dbContext.SaveChanges();
    }

    public async Task ChangeRole(string id, string newRole)
    {
        var user = await _userManager.FindByIdAsync(id);
        var role = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRoleAsync(user, role.First());
        await _userManager.AddToRoleAsync(user, newRole);
    }

    public async Task DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user != null)
        {
            await _userManager.DeleteAsync(user);
        }
    }
}