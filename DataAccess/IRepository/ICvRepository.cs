using BusinessObject.DataModel;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ICvRepository:IGenericRepository<Cv>
    {
        Task AddCv(Cv cv, long userId);
        Task<List<Cv>> GetAllCvByUserId(long userId);
       Task< Cv> GetFullCvByCvId(long cvId);

    }
}
