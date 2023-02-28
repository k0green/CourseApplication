using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CommentsModels;

namespace CourseApplication.Repositories
{
    public interface ICommentsRepository
    {
        public Task Create(UserItemComment comment);
        public Task<List<CommentsDisplayModel>> GetCommentsForItem(string id);
    }
}
