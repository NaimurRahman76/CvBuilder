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
    public class EducationRepository : GenericRepository<Education>,IEducationRepository
    {

        public EducationRepository(ApplicationDbContext db):base(db) { }
        
        public async Task AddEducation(Education education, long cvId)
        {
            var res =await _db.Cvs.Include(x => x.EducationList).FirstOrDefaultAsync(x => x.Id == cvId);
            if (res == null)
            {
                throw new Exception("No cv found for the cv Id");
            }
            if (res.EducationList == null) res.EducationList = new List<Education>();
            res.EducationList.Add(education);
        }

        public async Task<List<Education>> GetAllEducationByCvId(long cvId)
        {
            var list = new List<Education>();
            var res =await _db.Cvs.Include(x => x.EducationList).FirstOrDefaultAsync(x => x.Id == cvId);
            if (res != null && res.EducationList != null) list = res.EducationList;
            return list;
        }

        public async Task<bool> CheckCvById(long cvId)
        {
            var res =await _db.Cvs.FindAsync(cvId);
            if (res != null) return true;
            return false;
        }
        public async Task<bool> CheckEducationById(long educationId)
        {
            var res =await _db.Educations.FindAsync(educationId);
            if (res != null) return true;
            return false;
        }
    }
}
