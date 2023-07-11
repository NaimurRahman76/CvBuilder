
using AutoMapper;
using BusinessLogic.IServices;
using BusinessLogic.Validation;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using DataAccess.IRepository;

namespace BusinessLogic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfRepository _unitOfRepository;
        private readonly IMapper _mapper;
        public ProjectService(IUnitOfRepository unitOfRepository,IMapper mapper)
        {
            _unitOfRepository = unitOfRepository;
            _mapper = mapper;
        }
        public async Task AddProject(ProjectView projectView, long cvId)
        {
            var project = _mapper.Map<ProjelctView>(projectView);
            await _unitOfRepository.ProjectRepository.AddProject(project, cvId);
        }

        public async Task DeleteProjectById(long projectId)
        {
            if (projectId > 0)
            {
                await _unitOfRepository.ProjectRepository.Delete(projectId);
            }
            else
            {
                throw new Exception("Invalid projectId");
            }
        }

        public async Task<ProjectView> GetProjectById(long projectId)
        {

            var project= await _unitOfRepository.ProjectRepository.GetById(projectId);
            return _mapper.Map<ProjectView>(project);
        }

        public async Task<List<ProjectView>> GetAllProjectByCvId(long cvId)
        {
            var projectList= await _unitOfRepository.ProjectRepository.GetAllProjectByCvId(cvId);
            var projectViewList=projectList.Select(project=>_mapper.Map<ProjelctView,ProjectView>(project)).ToList();
            return projectViewList;
        }

        public async Task Save()
        {
           await _unitOfRepository.ProjectRepository.Save();
        }

        public async Task UpdateProject(ProjectView projectView)
        {
           var project = _mapper.Map<ProjelctView>(projectView);
           await _unitOfRepository.ProjectRepository.Update(project);
        }
    }
}
