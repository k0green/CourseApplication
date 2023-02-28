using AutoMapper;
using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldValueModels;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl;

public class CustomFieldValueRepositoryImpl : ICustomFieldsValuesRepository
{
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomFieldValueRepositoryImpl(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<CustomFieldsValues>> GetValuesByItemIdAsync(string itemId)
        {
            var values = await _dbContext.CustomFieldsValues.Where(x => x.ItemId == itemId).ToListAsync();
            return values;
        }
        
        public async Task<List<CustomFieldValueDisplayModel>> GetFieldsForItemAsync(string itemId)
        {
            var fields = await _dbContext.CustomFieldsValues
                .Where(x => x.ItemId == itemId)
                .Select(x =>
                new CustomFieldValueDisplayModel()
                {
                    Id = x.Id,
                    FieldName = x.CustomField.FieldName,
                    Value = x.Value,
                    ItemId = x.ItemId,
                    CollectionId = x.CustomField.CollectionId,
                    CustomFieldId = x.CustomField.Id,
                    ValueTypeId = x.CustomField.ValueTypeId
                }).ToListAsync();
            return fields;
        }
        
        public async Task<List<CustomFieldValueDisplayModel>> GetCustomFieldsForItem(string itemId)
        {
            var fields = await _dbContext.CustomFieldsValues
                .Where(x => x.ItemId == itemId)
                .Select(x => new CustomFieldValueDisplayModel()
                {
                    Id = x.Id,
                    FieldName = x.CustomField.FieldName,
                    Value = x.Value,
                    ItemId = x.ItemId,
                    CollectionId = x.CustomField.CollectionId,
                    CustomFieldId = x.CustomField.Id,
                    ValueTypeId = x.CustomField.ValueTypeId
                }).ToListAsync();
            return fields;
        }
        
        public async Task Add(CustomFieldsValues field)
        {
            field.Id = Guid.NewGuid().ToString();
            await _dbContext.CustomFieldsValues.AddAsync(field);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Edit(CustomFieldsValues field)
        {
            _dbContext.CustomFieldsValues.Update(field);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Delete(CustomFieldsValues field)
        {
            _dbContext.CustomFieldsValues.Remove(field);
            await _dbContext.SaveChangesAsync();
        }

}