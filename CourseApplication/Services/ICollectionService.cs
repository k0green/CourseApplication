using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;

namespace CourseApplication.Services
{
    public interface ICollectionService
    {
        public Task<CollectionDisplayModel> GetCollection(string id);
        public Task<List<CollectionDisplayModel>> GetTheMostPopularCollections();
        public Task<CollectionEditModel> GetCollectionForEdit(string id);
        public Task<List<CollectionDisplayModel>> GetUsersCollections(string id);
        public Task Delete(string id);
        public Task Edit(CollectionEditModel collection);
        public Task Create(CreateCollectionModel createCollection);

    }
}
