using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IProjectRepository:IGenericRepository<ProjelctView>
    {
        Task AddProject(ProjelctView porject, long cvId);
        Task<List<ProjelctView>> GetAllProjectByCvId(long cvId);
    }
}
