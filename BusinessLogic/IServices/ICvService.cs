using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface ICvService
    {
        Task AddCv(CvView cv, long userId);
        Task UpdateCv(CvView cv);
        Task DeleteCv(long cvId);
        Task Save();
        Task<List<CvView>> GetAllCvByUserId(long userId);
        Task<Cv> GetFullCvByCvId(long cvId);
    }
}
