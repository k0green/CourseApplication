using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CommentsModels;
using CourseApplication.Models.LikeModels;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class LikesServiceImpl : ILikesService
    {
        private readonly ILikesRepository _likesRepository;
        private readonly IMapper _mapper;

        public LikesServiceImpl(ILikesRepository likesRepository,
            IMapper mapper)
        {
            _likesRepository = likesRepository;
            _mapper = mapper;
        }

        public async Task<bool> GetLikeForUserItem(string itemId, string userId)
        {
            var like = await _likesRepository.GetLikeForUserItem(itemId, userId);
            if (like == null)
                return false;
            return true;
        }

        public async Task Create(LikeCreateModel model)
        {
            var like = await _likesRepository.GetLikeForUserItem(model.ItemId, model.UserId);
            if (like == null)
            {
                var likeEntity = _mapper.Map<UserItemLike>(model);
                await _likesRepository.Create(likeEntity);
            }
        }

        public async Task Remove(LikeCreateModel model)
        {
            var like = await _likesRepository.GetLikeForUserItem(model.ItemId, model.UserId);
            if(like!=null)
                await _likesRepository.Remove(like);
        }

    }
}
