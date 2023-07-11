using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IEducationService
    {
        Task AddEducation(EducationView education, long cvId);
        Task UpdateEducation(EducationView education);
        Task DeleteEducationById(long educationId);
        Task< List<EducationView>> GetAllEducationByCvId(long cvId);
        Task<EducationView> GetEducationById(long educationId);
        Task Save();
    }
}
