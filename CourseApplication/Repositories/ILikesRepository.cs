using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CommentsModels;

namespace CourseApplication.Repositories
{
    public interface ILikesRepository
    {
        public Task<UserItemLike> GetLikeForUserItem(string itemId, string userId);
        public Task Create(UserItemLike like);
        public Task Remove(UserItemLike like);
    }
}
