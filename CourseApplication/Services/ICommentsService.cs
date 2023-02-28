using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CommentsModels;

namespace CourseApplication.Services
{
    public interface ICommentsService
    {
        public Task<List<CommentsDisplayModel>> GetCommentsForItem(string id);
        public Task Create(CreateCommentModel model);

    }
}
