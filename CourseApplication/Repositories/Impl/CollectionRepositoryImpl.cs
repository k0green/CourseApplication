using AutoMapper;
using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl
{
    public class CollectionRepositoryImpl : ICollectionRepository
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CollectionRepositoryImpl(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<CollectionDisplayModel>> GetUsersCollections(string id)
        {
            var collections = await _dbContext.UserCollection.
                Where(x => x.UserId==id).
                Select(x=> new CollectionDisplayModel
                {
                    Id=x.CollectionId,
                    Name = x.Collection.Name,
                    Description= x.Collection.Description,
                    ThemeName = x.Collection.Them.Name,
                    UserId = id
                }).ToListAsync();
            return collections;
        }

        public async Task<CollectionDisplayModel> GetCollection(string id)
        {
            var collection = await _dbContext.Collection.Select(x=> new CollectionDisplayModel
            {
                Id=x.Id,
                Name = x.Name,
                Description= x.Description,
                ThemeName = x.Them.Name,
                PhotoUrl = x.PhotoUrl
            }).FirstAsync(x => x.Id == id);
            return collection;
        }
        
        public async Task Delete(string id)
        {
            var collection = await _dbContext.Collection.FirstOrDefaultAsync(x => x.Id == id);
            if (collection != null)
            {
                _dbContext.Collection.Remove(collection);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Edit(Collection collection)
        {
                _dbContext.Collection.Update(collection);
                await _dbContext.SaveChangesAsync();
        }

        public async Task Create(CreateCollectionModel model, string id)
        {
            if (model != null)
            {
                var collection =  _mapper.Map<Collection>(model);
                collection.Id = id;
                var userCollection = new UserCollection()
                {
                    UserId = model.CreatorId, 
                    CollectionId = collection.Id,
                };
                await _dbContext.AddAsync(collection);
                await _dbContext.UserCollection.AddAsync(userCollection);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
