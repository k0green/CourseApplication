using CourseApplication.Entities;
using CourseApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICollectionService _collectionService;
        private static string nameUser;
        public const string userIdSes = "_Id";

        public UsersController(IUserService userService,
            ICollectionService collectionService)
        {
            _userService = userService;
            _collectionService = collectionService;
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsersDisplayModel());
        }

        [Authorize]
        public async Task<IActionResult> PersonalArea(string name)
        {
            if (name!=null)
            {
                nameUser = name;
                //HttpContext.Session.SetString(userIdSes, $"{await _userService.GetIdByName(name)}");
                HttpContext.Response.Cookies.Append("_Id", $"{await _userService.GetIdByName(name)}");
            }
            if(User.IsInRole("user"))
                nameUser = User.Identity.Name;
            ViewBag.UserId = await _userService.GetIdByName(nameUser);//
            ViewBag.Title = $"{nameUser}";
            var collections = await _collectionService.GetUsersCollections(await _userService.GetIdByName(nameUser));            
            return View(collections);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            if (id != null)
            {
                await _userService.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> ChangeStatus(string id, string newStatus)
        {
            if (id != null && newStatus != null)
            {
                await _userService.ChangeStatus(id, newStatus);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> ChangeRole(string id, string newRole)
        {
            if (id != null && newRole != null)
            {
               await _userService.ChangeRole(id, newRole);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if(id!=null)
            {
                await _userService.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }
    }
}
