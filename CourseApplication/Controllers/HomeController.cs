using CourseApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using CourseApplication.Services;
using Microsoft.AspNetCore.Localization;

namespace CourseApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IThemService _themService;
        private readonly IItemService _itemService;
        private readonly ICollectionService _collectionService;
        private readonly ITagService _tagService;
        private static int _skipAmount = 0;

        public HomeController(ILogger<HomeController> logger,
            IThemService themService,
            IItemService itemService,
            ICollectionService collectionService,
            ITagService tagService)
        {
            _logger = logger;
            _themService = themService;
            _itemService = itemService;
            _collectionService = collectionService;
            _tagService = tagService;
        }
        
        [HttpPost]
        public IActionResult SetTheme(string theme)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Append("theme", theme, cookie);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularTag()
        {
            var tags = await _tagService.GetTHeMostPopularTags();
            return PartialView("_GetPopularTag", tags);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPopularCollections()
        {
            var collections = await _collectionService.GetTheMostPopularCollections();
            return PartialView("_GetPopularCollections", collections);
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Tags = await _tagService.GetTHeMostPopularTags();
            ViewBag.Collections = await _collectionService.GetTheMostPopularCollections();
            _skipAmount = 0;
            return View();
        }

        public async Task<IActionResult> GetNewItems()
        {
            var items = await _itemService.GetNewItems(_skipAmount);
            _skipAmount += 20;
            return PartialView("_GetNewItems", items);
        }
        
        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var them = await _themService.GetAllThems();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}