using DataAccess.Data;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class UnitOfRepository : IUnitOfRepository
    {
        public IBasicInfoRepository BasicInfoRepository { get; set; }
        public ICustomFieldRepository CustomFieldRepository { get; set; }
        public ICustomSectionRepository CustomSectionRepository { get; set; }
        public ICvRepository CvRepository { get; set; }
        public IEducationRepository EducationRepository { get; set; }
        public IExperienceRepository ExperienceRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public ISkillRepository SkillRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; } 

        public UnitOfRepository(ApplicationDbContext db)
        {
            BasicInfoRepository=new BasicInfoRepository(db);
            CustomFieldRepository=new CustomFieldRepository(db);
            CustomSectionRepository=new CustomSectionRepository(db);
            CvRepository =new CvRepository(db);
            EducationRepository=new EducationRepository(db);
            ExperienceRepository=new ExperienceRepository(db);
            ProjectRepository =new ProjectRepository(db);
            SkillRepository =new SkillRepository(db);
            AccountRepository =new AccountRepository(db);
        }

    }
}
