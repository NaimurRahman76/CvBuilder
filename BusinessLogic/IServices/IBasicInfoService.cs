using BusinessObject.ViewModel;

namespace BusinessLogic.IServices
{
    public interface IBasicInfoService
    {
        Task<BasicInfoView> GetBasicInfoByCvId(long cvId);
        Task UpdateBasicInfo(BasicInfoView basicInfo);
        Task DeleteBasicInfo(long cvId);
        Task<BasicInfoView> GetBasicInfoByBasicInfoId(long basicInfoId);
        Task AddBasicInfo(BasicInfoView basicInfo, long cvId);
        Task Save();
    }
}
