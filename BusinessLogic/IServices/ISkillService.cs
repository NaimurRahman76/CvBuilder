using BusinessObject.DataModel;
using BusinessObject.ViewModel;

namespace BusinessLogic.IServices
{
    public interface ISkillService
    {
        Task AddSkill(SkillView skill, long cvId);
        Task DeleteSkillById(long skillId);
        Task UpdateSkill(SkillView skill);
        Task<List<SkillView>> GetAllSkillByCvId(long cvId);
        Task<SkillView> GetSkillById(long skillId);
        Task Save();
    }
}
