using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUnitOfRepository
    {
        public IBasicInfoRepository BasicInfoRepository { get; set; }
        public ICustomFieldRepository CustomFieldRepository { get; set; }
        public ICustomSectionRepository CustomSectionRepository { get; set; }
        public ICvRepository CvRepository { get; set; }
        public IEducationRepository EducationRepository { get; set; }
        public IExperienceRepository ExperienceRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public ISkillRepository SkillRepository { get; set; }
        public IAccountRepository AccountRepository { get;set; }

       
    }
}
