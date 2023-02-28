using AutoMapper;
using CourseApplication.Data;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CustomFieldModels;
using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Repositories.Impl
{
    public class CustomFieldRepositoryImpl : ICustomFieldRepository
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomFieldRepositoryImpl(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<CustomFieldsDisplayModel>> GetCustomFieldsForCollection(string collectionId)
        {
            var fields = await _dbContext.CustomField.Where(x => x.CollectionId == collectionId).ToListAsync();
            var fieldsDemo = _mapper.Map<List<CustomFieldsDisplayModel>>(fields);
            return fieldsDemo;
        }

        public async Task<CustomField> GetCustomFieldByIdAsync(string fieldId)
        {
            var field = await _dbContext.CustomField.FirstAsync(x => x.Id == fieldId);
            return field;
        }
        
        public async Task AddCustomField(CustomField field, string collectionId)
        {
            field.Id = Guid.NewGuid().ToString();
            field.CollectionId = collectionId;
            await _dbContext.CustomField.AddAsync(field);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Edit(CustomField field)
        {
            _dbContext.CustomField.Update(field);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Delete(CustomField field)
        {
            _dbContext.CustomField.Remove(field);
            _dbContext.SaveChanges();
        }



    }
}
