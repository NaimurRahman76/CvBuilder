using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IUnitOfService
    {
        public IBasicInfoService BasicInfoService { get; set; }
        public ICustomFieldService CustomFieldService { get; set; }
        public ICustomSectionService CustomSectionService { get; set; } 
        public ICvService CvService { get; set; }
        public IEducationService EducationService { get; set; }
        public IExperienceService ExperienceService { get; set; }
        public IProjectService ProjectService { get; set; }
        public ISkillService SkillService { get; set; }
        public IAccountService AccountService { get;set; }

    }
}
