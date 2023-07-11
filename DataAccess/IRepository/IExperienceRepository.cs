using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IExperienceRepository:IGenericRepository<Experience>
    {
        Task AddExperience(Experience experience, long cvId);
        Task<List<Experience>> GetAllExperienceByCvId(long cvId);
        Task<bool> CheckExperienceById(long experienceId);
        Task<bool> CheckCvById(long cvId);
    }
}
