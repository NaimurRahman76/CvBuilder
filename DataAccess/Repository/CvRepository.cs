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

    public class CvRepository :GenericRepository<Cv> ,ICvRepository
    {
        public CvRepository(ApplicationDbContext db) : base(db) { }

        public async Task AddCv(Cv cv, long userId)
        {
            var user = await _db.Users.Include(u => u.CvList).FirstOrDefaultAsync(u => u.Id == userId);
            user.CvList.Add(cv);
        }
        public async Task<List<Cv>> GetAllCvByUserId(long userId)
        {
            var user =await _db.Users.FindAsync(userId);
            var res =await _db.Cvs.Where(x => x.User == user).ToListAsync();
            return res;
        }
        public async Task<Cv> GetFullCvByCvId(long cvId)
        {
            var cv =await _db.Cvs
                .Include(x => x.BasicInfo)
                .Include(x => x.EducationList)
                .Include(x => x.ExperienceList)
                .Include(x => x.SkillList)
                .Include(x => x.ProjectList)
                .Include(x => x.SectionList)
                .ThenInclude(c => c.CustomFieldList)
                .FirstOrDefaultAsync(x => x.Id == cvId);
            return cv;
        }

    }
}
