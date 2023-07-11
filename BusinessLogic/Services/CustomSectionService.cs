using AutoMapper;
using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using DataAccess.IRepository;

namespace BusinessLogic.Services
{
    public class CustomSectionService : ICustomSectionService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        public CustomSectionService(IUnitOfRepository unitOfRepository, IMapper mapper)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;
        }
        public async Task AddCustomSection(CustomSectionView customSectionView, long cvId)
        {
            if (customSectionView == null || customSectionView.SectionName == null) throw new Exception("Name can't be null");
            var customSection = _mapper.Map<CustomSection>(customSectionView);
            await _unitOfRepository.CustomSectionRepository.AddCustomSection(customSection, cvId);
        }

        public async Task DeleteCustomSection(long sectionId)
        {
           await _unitOfRepository.CustomSectionRepository.Delete(sectionId);
        }

        public async Task<CustomSectionView> GetSectionBySectionId(long sectionId)
        {
            
            var customSection= await _unitOfRepository.CustomSectionRepository.GetById(sectionId);
            var customSectionView=new CustomSectionView();
            return _mapper.Map(customSection, customSectionView);
        }

        public async Task<List<CustomSectionView>> GetAllCustomSectionByCvIdAsync(long cvId)
        {
            var customSectionList = await _unitOfRepository.CustomSectionRepository.GetAllCustomSectionAsync(cvId);
            var customSectionViewList=new List<CustomSectionView>();
            foreach(var customSection in customSectionList) 
            {
                var tempSection=new CustomSectionView();
                var res=_mapper.Map(customSection, tempSection);
                customSectionViewList.Add(res);
            }
            return customSectionViewList;
        }

        public async Task Save()
        {
           await _unitOfRepository.CustomSectionRepository.Save();
        }

        public async Task UpdateCustomSection(CustomSectionView customSectionView)
        {
            if (customSectionView == null || customSectionView.SectionName == null) throw new Exception("name can't be empty");
            var customSection = _mapper.Map<CustomSection>(customSectionView);
            await _unitOfRepository.CustomSectionRepository.Update(customSection);
        }
    }
}
