using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface ICustomFieldService
    {
        Task AddCustomField(CustomFieldView customFieldView, long sectionId);
        Task UpdateCustomField(CustomFieldView customFieldView);
        Task DeleteCustomField(long fieldId);
        Task Save();
       Task<List<CustomFieldView>> GetAllCustomFieldBySectionId(long sectionId);
       Task<CustomFieldView> GetCustomFieldByFieldId(long fieldId);

    }
}
