
using AutoMapper;
using BusinessLogic.IServices;
using BusinessLogic.Validation;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using DataAccess.IRepository;
using System.Text.RegularExpressions;


namespace BusinessLogic.Services
{
    public class BasicInfoService : IBasicInfoService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        public BasicInfoService(IUnitOfRepository unitOfRepository ,IMapper mapper)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;   
        }
        public async Task AddBasicInfo(BasicInfoView basicInfoView, long cvId)
        {
           var basicInfo=_mapper.Map<BasicInfo>(basicInfoView);
           await _unitOfRepository.BasicInfoRepository.AddBasicInfo(basicInfo, cvId);
        }

        public async Task DeleteBasicInfo(long basicInfoId)
        {
           // var exceptions=BasicInfoValidation.CheckId(basicInfoId);
            //if(exceptions.Count!=0)throw new AggregateException(exceptions);

            var basicInfo = await _unitOfRepository.BasicInfoRepository.GetById(basicInfoId);
            if (basicInfo != null)await _unitOfRepository.BasicInfoRepository.Delete(basicInfoId);
            else
            {
               // exceptions.Add(new Exception("Invalid id"));
               // throw new AggregateException(exceptions);
            }
        }

        public async Task<BasicInfoView> GetBasicInfoByCvId(long cvId)
        {
            //var exceptions= BasicInfoValidation.CheckId(cvId);
            //if(exceptions.Count!=0) throw new AggregateException(exceptions);
            var basicInfo = await _unitOfRepository.BasicInfoRepository.GetBasicInfoByCvId(cvId);
            var basicInfoView= new BasicInfoView();
            if (basicInfo != null)
            {
                _mapper.Map(basicInfo, basicInfoView); 
            }
            else basicInfoView = null;
            return basicInfoView;
        }

        public async Task<BasicInfoView> GetBasicInfoByBasicInfoId(long basicInfoId)
        {
            //var exceptions = BasicInfoValidation.CheckId(basicInfoId);
           // if (exceptions.Count != 0) throw new AggregateException(exceptions);
            var basicInfo= await _unitOfRepository.BasicInfoRepository.GetById(basicInfoId);
            var basicInfoView=new BasicInfoView();
            if (basicInfo != null)
            {
                _mapper.Map(basicInfo, basicInfoView);
            }
            else
            {
                //exceptions.Add(new Exception("invalid basicInfoId"));
                //throw new AggregateException(exceptions);
                basicInfoView = null;
            }
            return basicInfoView;
        }

        public async Task Save()
        {
            await _unitOfRepository.BasicInfoRepository.Save();
        }

        public async Task UpdateBasicInfo(BasicInfoView basicInfoView)
        {
            //var exceptions=BasicInfoValidation.Check(basicInfo);
            var basicInfo=new BasicInfo();
            _mapper.Map(basicInfoView, basicInfo);
            await _unitOfRepository.BasicInfoRepository.Update(basicInfo);  
            //else throw new AggregateException(exceptions);
        }
    }
}
