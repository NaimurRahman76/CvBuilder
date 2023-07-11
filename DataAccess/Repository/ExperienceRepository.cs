using BusinessObject.DataModel;
using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ExperienceRepository :GenericRepository<Experience> ,IExperienceRepository
    {
        public ExperienceRepository(ApplicationDbContext db):base(db) { }
        public async Task AddExperience(Experience experience, long cvId)
        {
            var res =await _db.Cvs.Include(x => x.ExperienceList).FirstOrDefaultAsync(x => x.Id == cvId);
            res.ExperienceList.Add(experience);
        }
        public async Task< List<Experience>> GetAllExperienceByCvId(long cvId)
        {
            var res =await _db.Cvs.Include(_ => _.ExperienceList).FirstOrDefaultAsync(ex => ex.Id == cvId);
            if (res.ExperienceList == null) return new List<Experience>();
            return res.ExperienceList;
        }
        public async Task<bool> CheckExperienceById(long experienceId)
        {
            return await _db.Experiences.FindAsync(experienceId) != null;
        }
        public async Task< bool> CheckCvById(long cvId)
        {
            return await _db.Cvs.FindAsync(cvId) != null;
        }
    }
}
