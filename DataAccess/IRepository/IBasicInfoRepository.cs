using BusinessObject.DataModel;

namespace DataAccess.IRepository
{
    public interface IBasicInfoRepository:IGenericRepository<BasicInfo>
    {
       public Task<BasicInfo> GetBasicInfoByCvId(long cvId);
      public  Task AddBasicInfo(BasicInfo basicInfo, long cvId);
    }
}
