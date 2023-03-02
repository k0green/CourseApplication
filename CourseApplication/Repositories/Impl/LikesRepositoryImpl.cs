using AutoMapper;
using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CommentsModels;
using CourseApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseApplication.Repositories.Impl
{
    public class LikesRepositoryImpl : ILikesRepository
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LikesRepositoryImpl(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<UserItemLike> GetLikeForUserItem(string itemId, string userId)
        {
            var like = await _dbContext.UserItemLike.FirstOrDefaultAsync(x => x.UserId == userId && x.ItemId == itemId);
            return like;
        }

        public async Task Create(UserItemLike like)
        {
            await _dbContext.AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Remove(UserItemLike like)
        {
            _dbContext.Remove(like);
            await _dbContext.SaveChangesAsync();
        }
    }
}
