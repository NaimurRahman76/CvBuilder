using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ICustomSectionRepository:IGenericRepository<CustomSection>
    {
        Task AddCustomSection(CustomSection customSection, long cvId);
        Task<List<CustomSection>> GetAllCustomSectionAsync(long cvId);
    }
}
