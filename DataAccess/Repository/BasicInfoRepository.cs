using BusinessObject.DataModel;
using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class BasicInfoRepository :GenericRepository<BasicInfo>, IBasicInfoRepository
    {
       
        public BasicInfoRepository(ApplicationDbContext db):base(db) { }

        public async Task AddBasicInfo(BasicInfo basicInfo, long cvId)
        {
            var cv =await _db.Cvs.Include(x => x.BasicInfo).FirstOrDefaultAsync(x => x.Id == cvId); ;
            if (cv != null)
            {
                cv.BasicInfo = basicInfo;
            }
        }
        public async Task<BasicInfo> GetBasicInfoByCvId(long cvId)
        {

            var res = await _db.Cvs.Include(x => x.BasicInfo).FirstOrDefaultAsync(o => o.Id == cvId);
            return res.BasicInfo;
        }
        public async Task Update(BasicInfo basicInfo)
        {
            var tempBasicInfo=await _dbSet.FindAsync(basicInfo.Id);
            tempBasicInfo.FullName= basicInfo.FullName;
            tempBasicInfo.Address= basicInfo.Address;
            tempBasicInfo.Biography= basicInfo.Biography;
            tempBasicInfo.Email= basicInfo.Email;
            tempBasicInfo.Picture= basicInfo.Picture;
        }

    }
}
