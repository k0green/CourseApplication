using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Repositories;

namespace CourseApplication.Services.Impl
{
    public class CollectionServiceImpl : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ICustomFieldService _customFieldService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public CollectionServiceImpl(ICollectionRepository collectionRepository,
            ICustomFieldService customFieldService,
            IItemService itemService,
            IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _customFieldService = customFieldService;
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<CollectionDisplayModel> GetCollection(string id) =>
            await _collectionRepository.GetCollection(id);

        public async Task<List<CollectionDisplayModel>> GetTheMostPopularCollections()
        {
            var collections = new List<CollectionDisplayModel>();
            var items = await _itemService.GetAllItems();
            var q = items.GroupBy(x => x.CollectionId)
                .Select(g => new {Value = g.Key, Count = g.Count()})
                .OrderByDescending(x=>x.Count);
            foreach (var x in q)
            {
                var collection = await _collectionRepository.GetCollection(x.Value);
                collections.Add(collection);
            }

            return collections.Take(5).ToList();
        }
        
        public async Task<CollectionEditModel> GetCollectionForEdit(string id)
        {
            var collection = await _collectionRepository.GetCollection(id);
            var fields = await _customFieldService.GetCustomFieldsForCollection(id);
            var editCollection = _mapper.Map<CollectionEditModel>(collection);
            editCollection.CustomFields = _mapper.Map<List<CustomFieldsEditModel>>(fields);
            return editCollection;
        }

        public async Task<List<CollectionDisplayModel>> GetUsersCollections(string id) => await _collectionRepository.GetUsersCollections(id);

        public async Task Create(CreateCollectionModel createCollection)
        {
            var collectionId = Guid.NewGuid().ToString();
            var fields = createCollection.CustomFields;
            createCollection.CustomFields = null;
            await _collectionRepository.Create(createCollection, collectionId);
            await _customFieldService.AddCustomField(fields, collectionId);
        }

        public async Task Edit(CollectionEditModel collection)
        {
            var collectionEntity = _mapper.Map<Collection>(collection);
            await _customFieldService.EditFields(collection.CustomFields, collection.Id);
            collectionEntity.CustomFields = null;
            await _collectionRepository.Edit(collectionEntity);
        } 

        public async Task Delete(string id) => await _collectionRepository.Delete(id);
    }
}
