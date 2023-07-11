using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IProjectService
    {
        Task AddProject(ProjectView porject, long cvId);
        Task<ProjectView> GetProjectById(long projectId);
        Task<List<ProjectView>> GetAllProjectByCvId(long cvId);
        Task DeleteProjectById(long projectId);
        Task UpdateProject(ProjectView project);
        Task Save();
    }
}
