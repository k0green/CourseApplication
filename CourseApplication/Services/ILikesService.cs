using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CommentsModels;
using CourseApplication.Models.LikeModels;

namespace CourseApplication.Services
{
    public interface ILikesService
    {
        public Task Remove(LikeCreateModel model);
        public Task Create(LikeCreateModel model);
        public Task<bool> GetLikeForUserItem(string itemId, string userId);
    }
}
