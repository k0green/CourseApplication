using System.Security.AccessControl;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Services;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    public class CollectionsController : Controller
    {
        ICollectionService _collectionService;
        IValueTypeService _valueTypeService;
        private readonly IThemService _themService;
        private readonly IItemService _itemService;

        private static string token =
            "sl.BZhT2s-N4YcrncDDz8hMUie5I35ENf5j5aNZBYxlnBjG8S4X7nITu1imYSNVRXh8oKwTZA-vEMHb0-SkUiHhL9X7XVjcNPRQ75Y1WhaHoXtC8uKGOdXedgLQP9dZL9IsVXA9brbq";
        public CollectionsController(ICollectionService collectionService,
            IThemService themService,
            IValueTypeService valueTypeService,
            IItemService itemService)
        {
            _collectionService = collectionService;
            _themService = themService;
            _valueTypeService = valueTypeService;
            _itemService = itemService;
        }

        public async Task<IActionResult> GetCollectionViewPage(string collectionId)
        {
            var collections = await _collectionService.GetCollection(collectionId);
            ViewBag.Items = await _itemService.GetCollectionsItems(collectionId);
            return View(collections);
        }
        
        public async Task<ActionResult> Delete(string id)
        {
            if (id != null)
            {
                await _collectionService.Delete(id);
            }
            return RedirectToAction("PersonalArea", "Users");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            ViewBag.Types = await _valueTypeService.GetAllTypes();
            ViewBag.Themes = await _themService.GetAllThems();
            var collection = await _collectionService.GetCollectionForEdit(id);
            return View(collection);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CollectionEditModel model)
        {
            if (ModelState.IsValid)
            {
                await _collectionService.Edit(model);
            }
            return RedirectToAction("PersonalArea", "Users");
        }
        
        [HttpGet]
        public async Task<IActionResult> Create(string userId, string photoUrl)
        {
            ViewBag.Themes = await _themService.GetAllThems();
            ViewBag.Types = await _valueTypeService.GetAllTypes();
            ViewBag.CreatorId = userId;
            ViewBag.PhotoUrl = HttpContext.Session.GetString("photoUrl");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionModel model)
        {
            if (ModelState.IsValid)
            {
                await _collectionService.Create(model);
            }
            return RedirectToAction("PersonalArea", "Users");
        }

        [HttpGet]
        public async Task<IActionResult> UploadPhoto(string userId)
        {
            ViewBag.UserId = userId;
            HttpContext.Response.Cookies.Append("userId", userId);
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromForm(Name = "file")] IFormFile formFile)
        {
            string url = "";
            using (var dbx = new DropboxClient(token))
            {
                string folder = @"/CourseApplication";
                using (var mem = new MemoryStream())
                {
                    await formFile.CopyToAsync(mem);
                    mem.Seek(0, SeekOrigin.Begin);
                    var updates = await dbx.Files.UploadAsync(folder + "/" + formFile.FileName, WriteMode.Overwrite.Instance,
                        body: mem);
                    var tx = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(folder + "/" + formFile.FileName);
                    url = tx.Url;
                    url = url.Replace("dl=0", "raw=1");
                }
            }
            HttpContext.Session.SetString("photoUrl", url);
            return Ok();
        }
        
    }
}
