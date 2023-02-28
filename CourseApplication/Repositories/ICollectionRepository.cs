using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;

namespace CourseApplication.Repositories
{
    public interface ICollectionRepository
    {
        /*public Task<CollectionEditModel> GetCollectionForEdit(string id);*/
        public Task<List<CollectionDisplayModel>> GetUsersCollections(string id);
        public Task Delete(string id);
        //public Task Edit(CollectionEditModel collection);
        public Task Edit(Collection collection);
        public Task Create(CreateCollectionModel createCollection, string id);
        public Task<CollectionDisplayModel> GetCollection(string id);
    }
}
