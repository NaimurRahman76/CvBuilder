using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface ICustomSectionService
    {
        Task AddCustomSection(CustomSectionView customSection, long cvId);
        Task<List<CustomSectionView>> GetAllCustomSectionByCvIdAsync(long cvId);
        Task UpdateCustomSection(CustomSectionView customSection);
        Task DeleteCustomSection(long sectionId);
        Task<CustomSectionView> GetSectionBySectionId(long sectionId);
        Task Save();
    }
}
