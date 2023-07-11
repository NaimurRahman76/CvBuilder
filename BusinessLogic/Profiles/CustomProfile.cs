using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using AutoMapper;

namespace BusinessLogic.Profiles
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
            CreateMap<BasicInfoView, BasicInfo>().ReverseMap();
            CreateMap<CustomField, CustomFieldView>().ReverseMap();
            CreateMap<CustomSection, CustomSectionView>().ReverseMap();
            CreateMap<Cv,CvView>().ReverseMap();
            CreateMap<Education, EducationView>().ReverseMap();
            CreateMap<Experience, ExperienceView>().ReverseMap();
            CreateMap<ProjelctView, ProjectView>().ReverseMap();
            CreateMap<Skill, SkillView>().ReverseMap();
            CreateMap<LoginView, User>().ReverseMap();
            CreateMap<SignUpView, User>().ReverseMap();
        }
    }
}
