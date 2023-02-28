﻿using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.ItemModel;

namespace CourseApplication.Services
{
    public interface IItemService
    {
        public Task<ItemsDisplayModel> GetItemAsync(string id);
        public Task<List<ItemsDisplayModel>> GetAllItems();
        public Task<List<ItemsDisplayModel>> GetNewItems(int skipAmount);
        public Task<List<ItemsDisplayModel>> GetAllItemByTagId(string tagId);
        public Task Create(CreateItemModel createItem);
        public Task Edit(EditItemModel item);
        public Task Delete(string id);
        public Task<List<ItemsDisplayModel>> GetCollectionsItems(string id);
        public Task<EditItemModel> GetItemForEdit(string id);
        public Task<GetFieldsNameModel> GetItemForCreate(string id);

    }
}
