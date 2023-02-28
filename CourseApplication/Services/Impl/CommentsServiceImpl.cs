using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CommentsModels;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class CommentsServiceImpl : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsServiceImpl(ICommentsRepository commentsRepository,
            IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentsDisplayModel>> GetCommentsForItem(string id)
            => await _commentsRepository.GetCommentsForItem(id);

        public async Task Create(CreateCommentModel model)
        {
            var comment = _mapper.Map<UserItemComment>(model);
            comment.CreateTime = DateTime.Now;
            await _commentsRepository.Create(comment);
        }
    }
}
