using BusinessLogic.IServices;
using BusinessObject.DataModel;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public ProjectController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<IActionResult> Index()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var projects = await _unitOfService.ProjectService.GetAllProjectByCvId(cvId);
            return View(projects);
        }
        public IActionResult Add()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectView project)
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.ProjectService.AddProject(project, cvId);
                    await _unitOfService.ProjectService.Save();
                    return RedirectToAction("Index", "Project");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(project);
                }
            }
            else
            {
                return View(project);
            }

        }

        public async Task<IActionResult> Update(long projectId)
        {

            try
            {
                var project = await _unitOfService.ProjectService.GetProjectById(projectId);
                return View(project);
            } 
            catch (Exception ex)
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectView project)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.ProjectService.UpdateProject(project);
                    await _unitOfService.ProjectService.Save();
                    return RedirectToAction("Index", "Project");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(project);
                }
            }
            else
            {
                return View(project);
            }

        }

        public async Task<IActionResult> Delete(long projectId)
        {
            try
            {
                await _unitOfService.ProjectService.DeleteProjectById(projectId);
                await _unitOfService.ProjectService.Save();
                return RedirectToAction("Index", "Project");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", "unable to delete");
                return View();
            }
           
        }
    }
}
