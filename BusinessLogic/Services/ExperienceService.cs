
using AutoMapper;
using BusinessLogic.IServices;
using BusinessLogic.Validation;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{


    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        public ExperienceService(IUnitOfRepository unitOfRepository,IMapper mapper)
        {
           _unitOfRepository = unitOfRepository;
            _mapper = mapper;
        }
        public async Task AddExperience(ExperienceView experienceView, long cvId)
        {

            var res =await _unitOfRepository.ExperienceRepository.CheckCvById(cvId);
            if (res == false)
            {
                throw new Exception("Invalid cvid for adding new cv");
            }
            var experience=_mapper.Map<ExperienceView,Experience>(experienceView);
            await _unitOfRepository.ExperienceRepository.AddExperience(experience, cvId);
        }

        public async Task DeleteExperience(long experienceId)
        {
            var res =await _unitOfRepository.ExperienceRepository.CheckExperienceById(experienceId);
            if (res == false)
            {
                throw new Exception("Invalid experience Id for deletion");
            }
           await _unitOfRepository.ExperienceRepository.Delete(experienceId);
        }

        public async Task<List<ExperienceView>> GetAllExperienceByCvId(long cvId)
        {
            var res =await _unitOfRepository.ExperienceRepository.CheckCvById(cvId);
            if (res == false)
            {
                throw new Exception("Invalid cvId to get cvList");
            }
            var experienceList = await _unitOfRepository.ExperienceRepository.GetAllExperienceByCvId(cvId);
            var experienceViewList=experienceList.Select(x=>_mapper.Map<Experience,ExperienceView>(x)).ToList();
            return experienceViewList;
        }

        public async Task<ExperienceView> GetExperienceById(long experienceId)
        {
            var res =await _unitOfRepository.ExperienceRepository.CheckExperienceById(experienceId);
            if (res == false)
            {
                throw new Exception("Invalid experience Id to get a experience");
            }
            var experience =  await _unitOfRepository.ExperienceRepository.GetById(experienceId);
            return _mapper.Map<ExperienceView>(experience);
        }

        public async Task Save()
        {
           await _unitOfRepository.ExperienceRepository.Save();
        }

        public async Task UpdateExperience(ExperienceView experienceView)
        {
            var res =await _unitOfRepository.ExperienceRepository.CheckExperienceById(experienceView.Id);
            if (res == false)
            {
                throw new Exception("Invalid experience id for updating experience");

            }
            var experience=_mapper.Map<Experience>(experienceView);
            await _unitOfRepository.ExperienceRepository.Update(experience);
        }
    }
}
