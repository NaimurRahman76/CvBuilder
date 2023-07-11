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
    public class CvService : ICvService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;

        public CvService(IUnitOfRepository unitOfRepository,IMapper mapper)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;
        }
        public async Task AddCv(CvView cvView, long userId)
        {
            if (userId <= 0) throw new Exception("id can't be zero or negative");
            var cv=_mapper.Map<Cv>(cvView);
           await _unitOfRepository.CvRepository.AddCv(cv, userId);
        }

        public async Task DeleteCv(long id)
        {
            if (id == null || id <= 0) throw new ArgumentNullException("Invalid cvId");
            else
            {
               await _unitOfRepository.CvRepository.Delete(id);
            }
        }

        public async Task<List<CvView>> GetAllCvByUserId(long userId)
        {
            if (userId <= 0) throw new AggregateException("invalid userId");
            var cvList =await _unitOfRepository.CvRepository.GetAllCvByUserId(userId);
            var cvViewList = cvList.Select(cv => _mapper.Map<CvView>(cv)).ToList();
            return cvViewList;
        }

        public async Task Save()
        {
           await _unitOfRepository.CvRepository.Save();
        }

        public async Task UpdateCv(CvView cvView)
        {
            if (cvView == null) throw new AggregateException("cv can't be null");
            else
            {
               var cv=_mapper.Map<Cv>(cvView);
               await _unitOfRepository.CvRepository.Update(cv);
            }
        }
        public async Task<Cv> GetFullCvByCvId(long cvId)
        {
            if (cvId == null || cvId <= 0) throw new ArgumentNullException("Invalid cvId");
            var cv= await _unitOfRepository.CvRepository.GetFullCvByCvId(cvId);
            return cv;
        }
    }
}
