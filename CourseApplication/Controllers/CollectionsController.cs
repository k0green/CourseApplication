using System.Net;
using System.Security.AccessControl;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Services;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net.Http;

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

        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            if (id != null)
            {
                await _collectionService.Delete(id);
            }
            return RedirectToAction("PersonalArea", "Users");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            ViewBag.Types = await _valueTypeService.GetAllTypes();
            ViewBag.Themes = await _themService.GetAllThems();
            var collection = await _collectionService.GetCollectionForEdit(id);
            return View(collection);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(CollectionEditModel model)
        {
            if (ModelState.IsValid)
            {
                await _collectionService.Edit(model);
            }
            else
            {
                ViewBag.Types = await _valueTypeService.GetAllTypes();
                ViewBag.Themes = await _themService.GetAllThems();
                var collection = await _collectionService.GetCollectionForEdit(model.Id);
                return View(collection);
            }
            return RedirectToAction("PersonalArea", "Users");
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create(string userId)
        {
            ViewBag.Themes = await _themService.GetAllThems();
            ViewBag.Types = await _valueTypeService.GetAllTypes();
            ViewBag.CreatorId = userId;
            ViewBag.PhotoUrl = HttpContext.Request.Cookies["photoUrl"];
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionModel model)
        {
            if (ModelState.IsValid)
                await _collectionService.Create(model);
            else
            {
                ViewBag.Themes = await _themService.GetAllThems();
                ViewBag.Types = await _valueTypeService.GetAllTypes();
                ViewBag.CreatorId = model.CreatorId;
                ViewBag.PhotoUrl = HttpContext.Request.Cookies["photoUrl"];
                return View();
            }
            return RedirectToAction("PersonalArea", "Users");
        }

        [Authorize]
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
            HttpContext.Response.Cookies.Append("photoUrl", url);
            return Ok();
        }
        
    }
}
