using CourseApplication.Models.CollectionModels;
using CourseApplication.Services;
using Dropbox.Api;
using Dropbox.Api.Files;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CourseApplication.Controllers
{
    public class CollectionsController : Controller
    {
        ICollectionService _collectionService;
        IValueTypeService _valueTypeService;
        private readonly IThemService _themService;
        private readonly IItemService _itemService;

        private readonly IHostEnvironment _env;
        private static string ApiKey = "AIzaSyAUT9wX5xDenI1ABuog8jYPnhyJNMmLGqw";
        private static string Bucket = "cwproj-a91ca.appspot.com";
        private static string AuthEmail = "cwuser@gmail.com";
        private static string AuthPassword = "12345aA!";


        private static string token =
            "sl.BaFsuqLL6DGNLVW-mztXtpbu54t8Bu85aOBFZKlQkn8kx5J-ZPIJYp2zam45dbBYieR1z_gOJt4aOTJhTcPCnxe4hxOm3BIu_F5DR8_Czrke-uAAe-1ioLiKS9mp0bITeHWgKYNU";
        public CollectionsController(ICollectionService collectionService,
            IThemService themService,
            IValueTypeService valueTypeService,
            IItemService itemService,
            IHostEnvironment env)
        {
            _collectionService = collectionService;
            _themService = themService;
            _valueTypeService = valueTypeService;
            _itemService = itemService;
            _env = env;
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
            HttpContext.Response.Cookies.Delete("photoUrl");
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
                //string folder = @"/DeleteCW";
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
        
        [HttpPost]
        public async Task<IActionResult> GetPhoto([FromForm(Name = "file")] IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                using (var mem = new MemoryStream())
                {
                    await formFile.CopyToAsync(mem);
                    mem.Seek(0, SeekOrigin.Begin);
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                    var cancellation = new CancellationTokenSource();

                    var task = new FirebaseStorage(
                            Bucket,
                            new FirebaseStorageOptions
                            {
                                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                ThrowOnCancel = true
                            })
                        .Child("receipts")
                        .Child(formFile.FileName)
                        .PutAsync(mem, cancellation.Token);
                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");


                    HttpContext.Response.Cookies.Append("photoUrl", task.TargetUrl);
                }
            }

            return Ok();
        }

        

    }
}
