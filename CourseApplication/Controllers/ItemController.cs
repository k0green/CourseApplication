using CourseApplication.Models.CommentsModels;
using CourseApplication.Models.ItemModel;
using CourseApplication.Models.LikeModels;
using CourseApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseApplication.Controllers
{
    public class ItemController : Controller
    {

        IItemService _itemService;
        private readonly ICustomFieldValueService _valueService; 
        private readonly ITagService _tagService;
        private readonly ICustomFieldService _customFieldService;
        private readonly ICommentsService _commentsService;
        private readonly IUserService _userService;
        private readonly ILikesService _likesService;

        public ItemController(IItemService ItemService,
            ITagService tagService,
            ICustomFieldValueService valueService,
            ICommentsService commentsService,
            IUserService userService,
            ILikesService likesService,
            ICustomFieldService customFieldService)
        {
            _itemService = ItemService;
            _tagService = tagService;
            _valueService = valueService;
            _commentsService = commentsService;
            _userService = userService;
            _customFieldService = customFieldService;
            _likesService = likesService;
        }

        [HttpGet]
        public async Task<IActionResult> ItemViewPage(string itemId)
        {
            var userId = await _userService.GetIdByName(User.Identity.Name);
            var item = await _itemService.GetItemAsync(itemId);
            ViewBag.CustomFields = await _valueService.GetFieldsForItemAsync(itemId);
            ViewBag.Comments = await _commentsService.GetCommentsForItem(itemId);
            ViewBag.Like = await _likesService.GetLikeForUserItem(itemId, userId);
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(string itemId)
        {
            var comments = await _commentsService.GetCommentsForItem(itemId);
            return PartialView("_GetComments", comments);
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(CreateCommentModel model)
        {
            model.UserId = await _userService.GetIdByName(User.Identity.Name);
            await _commentsService.Create(model);
            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddLike(LikeCreateModel model)
        {
            model.UserId = await _userService.GetIdByName(User.Identity.Name);
            await _likesService.Create(model);
            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult> RemoveLike(LikeCreateModel model)
        {
            model.UserId = await _userService.GetIdByName(User.Identity.Name);
            await _likesService.Remove(model);
            return Ok();
        }
        
        public async Task<IActionResult> GetAllItemByTagId(string tagId)
        {
            var items = await _itemService.GetAllItemByTagId(tagId);
            return View(items);
        }
        
        /*[HttpPost]
        public async Task<ActionResult> AddComment(string comment, string userId, string itemId)
        {
            return Ok();
        }*/
        
        public async Task<ActionResult> Delete(string id, string collectionId)
        {
            if (id != null)
            {
                await _itemService.Delete(id);
            }
            return Redirect($"~/Item/GetAllItemForOneCollection?collectionId=" + collectionId);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var item = await _itemService.GetItemForEdit(id);
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditItemModel model)
        {
            if (ModelState.IsValid)
            {
                await _itemService.Edit(model);
            }
            return Redirect($"~/Item/GetAllItemForOneCollection?collectionId=" + model.CollectionId);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var id = HttpContext.Session.GetString("_CollectionId");
            var customFields = await _customFieldService.GetCustomFieldsForCollection(id);
            ViewBag.CollectionId = id;
            return View(customFields);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateItemModel model)
        {
            if (ModelState.IsValid)
            {
                await _itemService.Create(model);
            }
            return Redirect($"~/Item/GetAllItemForOneCollection?collectionId=" + model.CollectionId);
        }

        public async Task<IActionResult> GetAllItemForOneCollection(string collectionId)
        {
            HttpContext.Session.SetString("_CollectionId", $"{collectionId}");
            var items = await _itemService.GetCollectionsItems(collectionId);
            return View(items);
        }

        [HttpPost]
        public async Task<JsonResult> AutoComplete(string prefix)
        {
            var users = await _tagService.GetAllTags();
            var persons = (from person in users
                           where person.Name.StartsWith(prefix)
                           select new
                           {
                               label = person.Name,
                               val = person.Name
                           }).Take(5).ToList();

            return Json(persons);
        }
    }
}
