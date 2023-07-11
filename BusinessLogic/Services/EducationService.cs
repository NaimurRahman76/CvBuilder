using AutoMapper;
using BusinessLogic.IServices;
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
    public class EducationService : IEducationService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;

        public EducationService(IUnitOfRepository unitOfRepository,IMapper mapper)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;
        }
        public async Task AddEducation(EducationView educationView, long cvId)
        {
            var res =await _unitOfRepository.EducationRepository.CheckCvById(cvId);
            if (res == false)
            {
                throw new Exception("Invalid cv id for adding new education");
            }
            var education=_mapper.Map<Education>(educationView);
            await _unitOfRepository.EducationRepository.AddEducation(education, cvId);
        }

        public async Task DeleteEducationById(long educationId)
        {
            var res =await _unitOfRepository.EducationRepository.CheckEducationById(educationId);
            if (res == false)
            {
                throw new Exception("Invalid education id for deleting");
            }
            else
            {
               await _unitOfRepository.EducationRepository.Delete(educationId);
            }

        }

        public async Task<EducationView> GetEducationById(long educationId)
        {
            var res =await _unitOfRepository.EducationRepository.CheckEducationById(educationId);
            if (res == false)
            {
                throw new Exception("Invalid education id for getting education");
            }
            else
            {
                var education= await _unitOfRepository.EducationRepository.GetById(educationId);
                return _mapper.Map<EducationView>(education);
            }

        }

        public async Task<List<EducationView>> GetAllEducationByCvId(long cvId)
        {
            var res =await _unitOfRepository.EducationRepository.CheckCvById(cvId);
            if (res == false)
            {
                throw new Exception("Invalid cvId for getting All Accociative cv");
            }
            else
            {
                var educationList= await _unitOfRepository.EducationRepository.GetAllEducationByCvId(cvId);
                var educationViewList=educationList.Select(education=>_mapper.Map<Education,EducationView>(education)).ToList();
                return educationViewList;
            }
        }

        public async Task UpdateEducation(EducationView educationView)
        {
            var res =await _unitOfRepository.EducationRepository.CheckEducationById(educationView.Id);
            if (res == false)
            {
                throw new Exception("Update failed because id has been modified");
            }
            else
            {
                var education=_mapper.Map<EducationView,Education>(educationView);
                await _unitOfRepository.EducationRepository.Update(education);
            }

        }
        public async Task Save()
        {
           await _unitOfRepository.EducationRepository.Save();
        }
    }
}
