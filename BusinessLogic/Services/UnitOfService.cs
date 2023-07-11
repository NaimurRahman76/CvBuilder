using AutoMapper;
using BusinessLogic.IServices;
using BusinessLogic.Services;
using DataAccess.Data;
using DataAccess.IRepository;

namespace BusinessLogic.Services
{
    public class UnitOfService : IUnitOfService
    {
        public IBasicInfoService BasicInfoService { get; set; }
        public ICustomFieldService CustomFieldService { get; set; }
        public ICustomSectionService CustomSectionService { get; set; }
        public ICvService CvService { get; set; }
        public IEducationService EducationService { get; set; }
        public IExperienceService ExperienceService { get; set; }
        public IProjectService ProjectService { get; set; }
        public ISkillService SkillService { get; set; }
        public IAccountService AccountService { get; set; }
        public UnitOfService(IUnitOfRepository db,IMapper mapper,EmailService emailService)
        {
            BasicInfoService = new BasicInfoService(db,mapper);
            CustomFieldService = new CustomFieldService(db,mapper);
            CustomSectionService = new CustomSectionService(db,mapper);
            CvService = new CvService(db,mapper);
            EducationService = new EducationService(db,mapper);
            ExperienceService = new ExperienceService(db,mapper);
            ProjectService = new ProjectService(db,mapper);
            SkillService = new SkillService(db,mapper);
            AccountService = new AccountService(db, mapper,emailService);
        }
    }
}
