using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ICustomFieldRepository:IGenericRepository<CustomField>
    {
        Task AddCustomField(CustomField customField, long sectionId);
        Task<List<CustomField>> GetAllCustomFieldBySectionId(long sectionId);
        Task<bool> CheckFieldByFieldId(long fieldId);
        Task<bool> CheckSectionBySectionId(long sectionId);

    }
}
