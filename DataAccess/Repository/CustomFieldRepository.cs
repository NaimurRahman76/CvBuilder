using BusinessObject.DataModel;
using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CustomFieldRepository : GenericRepository<CustomField> ,ICustomFieldRepository
    {
        public CustomFieldRepository(ApplicationDbContext db) : base(db) { }
        public async Task AddCustomField(CustomField customField, long sectionId)
        {
            var section =await _db.CustomSections.Include(x => x.CustomFieldList).FirstOrDefaultAsync(o => o.Id == sectionId);
            section.CustomFieldList.Add(customField);
        }

        public async Task<bool> CheckFieldByFieldId(long fieldId)
        {
            var res =await _db.CustomFields.FindAsync(fieldId);
            if (res != null) { return true; }
            return false;
        }

        public async Task<bool> CheckSectionBySectionId(long sectionId)
        {
            var res = await _db.CustomSections.FindAsync(sectionId);
            if (res != null) { return true; }
            return false;
        }

        public async Task<List<CustomField>> GetAllCustomFieldBySectionId(long sectionId)
        {
            var list = new List<CustomField>();
            var section =await _db.CustomSections.Include(x => x.CustomFieldList).FirstOrDefaultAsync(x => x.Id == sectionId);
            list = section.CustomFieldList;
            return list;
        }
        public async Task Update(CustomField customField)
        {
            var tempCustomField=await _dbSet.FindAsync(customField.Id);
            tempCustomField.FieldValueNumber = customField.FieldValueNumber;
            tempCustomField.FieldValueDate = customField.FieldValueDate;
            tempCustomField.FieldValueText = customField.FieldValueText;
            tempCustomField.FieldValueString = customField.FieldValueString;
            tempCustomField.FieldName = customField.FieldName;
            tempCustomField.FieldType = customField.FieldType;
            
        }
    }
}
