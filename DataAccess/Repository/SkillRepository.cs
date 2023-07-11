using BusinessObject.DataModel;
using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class SkillRepository :GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext db) : base(db) { }
        public async Task AddSkill(Skill skill, long cvId)
        {
            var tempCv =await _db.Cvs.Include(x => x.SkillList).FirstOrDefaultAsync(ex => ex.Id == cvId);
            tempCv.SkillList.Add(skill);
        }

        public async Task<bool> CheckCvById(long cvId)
        {
            return await _db.Cvs.FindAsync(cvId) != null;
        }

        public async Task<bool> CheckSkillById(long skillId)
        {
            return await _db.Skills.FindAsync(skillId) != null;
        }

        public async Task<List<Skill>> GetAllSkillByCvId(long cvId)
        {
            var list = new List<Skill>();
            var tempCv =await _db.Cvs.Include(_ => _.SkillList).FirstOrDefaultAsync(x => x.Id == cvId);
            list = tempCv.SkillList;
            return list;
        }
    }
}
