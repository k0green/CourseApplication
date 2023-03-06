using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Repositories;
using CourseApplication.Search;
using CourseApplication.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    public class SearchController  : Controller
    {
        public SearchResultCollection Results { get; set; }
        public string Search { get; set; }

        [HttpGet]
        public IActionResult FindSmth()
        {
            Results = new SearchResultCollection();
            return View(Results);
        }
    }
}
