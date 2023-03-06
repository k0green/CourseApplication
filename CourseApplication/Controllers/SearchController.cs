using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Repositories;
using CourseApplication.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    public class CultureController  : Controller
    {

        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
            );
            Response.Cookies.Append("locale", $"{culture}");
            return LocalRedirect(returnUrl);
        }
    }
}
