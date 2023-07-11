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
    public class CustomFieldService : ICustomFieldService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        public CustomFieldService(IUnitOfRepository unitOfRepository,IMapper mapper)
        {
           _unitOfRepository = unitOfRepository;    
            _mapper = mapper;
        }
        public async Task AddCustomField(CustomFieldView customFieldView, long sectionId)
        {
            var check =await _unitOfRepository.CustomFieldRepository.CheckSectionBySectionId(sectionId);
            if (check == false)
            {
                throw new Exception("Invalid section id while adding new field");
            }
            var customField=_mapper.Map<CustomField>(customFieldView);
            await  _unitOfRepository.CustomFieldRepository.AddCustomField(customField, sectionId);
        }

        public async Task DeleteCustomField(long fieldId)
        {
            var check =await _unitOfRepository.CustomFieldRepository.CheckFieldByFieldId(fieldId);
            if (check == false)
            {
                throw new Exception("Invalid fieldId");
            }
          await  _unitOfRepository.CustomFieldRepository.Delete(fieldId);
        }

        public async Task<CustomFieldView> GetCustomFieldByFieldId(long fieldId)
        {
            var customField= await _unitOfRepository.CustomFieldRepository.GetById(fieldId);
            var customFieldView=new CustomFieldView();
            return _mapper.Map(customField,customFieldView);
        }
        public async Task<List<CustomFieldView>> GetAllCustomFieldBySectionId(long sectionId)
        {
            var customFieldList = await _unitOfRepository.CustomFieldRepository.GetAllCustomFieldBySectionId(sectionId);
            var customFieldViewList=new List<CustomFieldView>();
            foreach (var customField in customFieldList)
            {
                var tempCustomFieldView=new CustomFieldView();
                var customFieldView = _mapper.Map(customField, tempCustomFieldView);
                customFieldViewList.Add(customFieldView);
            }
            return customFieldViewList;
        }
        public async Task Save()
        {
           await _unitOfRepository.CustomFieldRepository.Save();
        }

        public async Task UpdateCustomField(CustomFieldView customFieldView)
        {
            var customField= _mapper.Map<CustomField>(customFieldView);
            await _unitOfRepository.CustomFieldRepository.Update(customField);
        }
    }
}
