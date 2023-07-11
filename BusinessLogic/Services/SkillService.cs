using AutoMapper;
using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using DataAccess.IRepository;


namespace BusinessLogic.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        public SkillService(IUnitOfRepository unitOfRepository,IMapper mapper)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;
        }
        public async Task AddSkill(SkillView skillView, long cvId)
        {
            var exceptions = new List<Exception>();
            if (cvId <= 0)
            {
                throw new Exception("Cv id need to be greater than 0 whicle adding new skill");
            }
            var tempCv =await _unitOfRepository.SkillRepository.CheckCvById(cvId);
            if (tempCv == false)
            {
                throw new Exception("Invalid cv Id while adding new skill");
            }
            else
            {
               var skill=_mapper.Map<Skill>(skillView);
               await  _unitOfRepository.SkillRepository.AddSkill(skill, cvId);
            }
        }

        public async Task DeleteSkillById(long skillId)
        {
            if (skillId <= 0)
            {
                throw new Exception("Skill id need to be greater than 0 while deleting a skill");
            }
            var tempSkill =await _unitOfRepository.SkillRepository.CheckSkillById(skillId);
            if (tempSkill == false)
            {
                throw new Exception("Invalid SkillId for deleting the skill");
            }
            else
            {
               await _unitOfRepository.SkillRepository.Delete(skillId);
            }
        }

        public async Task<List<SkillView>> GetAllSkillByCvId(long cvId)
        {
            if (cvId <= 0)
            {
                throw new Exception("Cv id need to be greater than 0 while getting all skill List");
            }
            var tempCv =await _unitOfRepository.SkillRepository.CheckCvById(cvId);
            if (tempCv == false)
            {
                throw new Exception("Invalid CvID to get all skill List");
            }
            else
            {

                var skillList= await _unitOfRepository.SkillRepository.GetAllSkillByCvId(cvId);
                var skillViewList = skillList.Select(skill=>_mapper.Map<Skill,SkillView>(skill)).ToList();
                return skillViewList;   
            }

        }

        public async Task<SkillView> GetSkillById(long skillId)
        {
            if (skillId <= 0)
            {
                throw new Exception("skill id need to be greater than 0 while getting a skill");
            }
            var tempSkill =await _unitOfRepository.SkillRepository.GetById(skillId);
            if (tempSkill == null)
            {
                throw new Exception("Invalid SkillId to get the skill ");
            }
            else
            {
                return _mapper.Map<Skill,SkillView>(tempSkill);
            }
        }

        public async Task Save()
        {
            await _unitOfRepository.SkillRepository.Save();
        }

        public async Task UpdateSkill(SkillView skillView)
        {
            var skill= _mapper.Map<SkillView,Skill>(skillView);
            await _unitOfRepository.SkillRepository.Update(skill);

        }
    }
}
