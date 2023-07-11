using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ISkillRepository:IGenericRepository<Skill>
    {
        Task AddSkill(Skill skill, long cvId);
       Task<List<Skill>> GetAllSkillByCvId(long cvId);
        Task<bool> CheckCvById(long cvId);
        Task<bool> CheckSkillById(long skillId);

    }
}
