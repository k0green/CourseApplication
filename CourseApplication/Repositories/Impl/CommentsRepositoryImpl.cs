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
    public class CommentsRepositoryImpl : ICommentsRepository
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentsRepositoryImpl(ApplicationDbContext applicationDbContext,
            IThemService themService,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<CommentsDisplayModel>> GetCommentsForItem(string id)
        {
            var comments = await _dbContext.UserItemComment.Where(x => x.ItemId == id).Select(x => new CommentsDisplayModel
            {
                ItemId = x.ItemId,
                UserId = x.UserId,
                UserName = x.User.UserName,
                Comment = x.Comment,
                CreateTime = x.CreateTime
            }).ToListAsync();
            return comments;
        }

        public async Task Create(UserItemComment comment)
        {
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
