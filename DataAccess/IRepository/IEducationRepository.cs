using BusinessObject.DataModel;

namespace DataAccess.IRepository
{
    public interface IEducationRepository:IGenericRepository<Education>
    {
        Task AddEducation(Education education, long cvId);
        Task<List<Education>> GetAllEducationByCvId(long cvId);
        Task<bool> CheckCvById(long cvId);
        Task<bool> CheckEducationById(long educationId);
    }
}
