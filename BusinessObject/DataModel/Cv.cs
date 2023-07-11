
using BusinessObject.DataModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.DataModel
{
    public class Cv : Default
    {
        [Required]
        public string CvName { get; set; }
        [Required]
        public string CvType { get; set; }
        public BasicInfo BasicInfo { get; set; }
        public List<Education> EducationList { get; set; }
        public List<Experience> ExperienceList { get; set; }
        public List<Skill> SkillList { get; set; }
        public List<CustomSection> SectionList { get; set; }
        public List<ProjelctView> ProjectList { get; set; }
        public User User { get; set; }
    }
}
