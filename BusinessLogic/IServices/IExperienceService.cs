using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IExperienceService
    {
        Task AddExperience(ExperienceView experience, long cvId);
        Task DeleteExperience(long experienceId);
        Task UpdateExperience(ExperienceView experience);
        Task<List<ExperienceView>> GetAllExperienceByCvId(long cvId);
        Task<ExperienceView> GetExperienceById(long experienceId);
        Task Save();
    }
}
