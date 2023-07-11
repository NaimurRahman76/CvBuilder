using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public ExperienceController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<IActionResult> Index()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");

            var experiences =await _unitOfService.ExperienceService.GetAllExperienceByCvId(cvId);
            return View(experiences);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(ExperienceView experience)
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.ExperienceService.AddExperience(experience, cvId);
                    await _unitOfService.ExperienceService.Save();
                    return RedirectToAction("Index", "Experience");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(experience);
                }
            }
            else
            {
                return View(experience);
            }

        }

        public async Task<IActionResult> Delete(long experienceId, long cvId)
        {
            await _unitOfService.ExperienceService.DeleteExperience(experienceId);
            await _unitOfService.ExperienceService.Save();
            return RedirectToAction("Index", "Experience", new { cvId });
        }
        public async Task<IActionResult> Update(long experienceId)
        {
            var experience =await _unitOfService.ExperienceService.GetExperienceById(experienceId);
            return View(experience);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExperienceView experience)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.ExperienceService.UpdateExperience(experience);
                    await _unitOfService.ExperienceService.Save();
                    return RedirectToAction("Index", "Experience");
                }
                catch (AggregateException ex)
                {
                    foreach (var ex2 in ex.InnerExceptions) ModelState.AddModelError("error", ex2.Message);
                    return View(experience);
                }
            }
            else
            {
                return View(experience);    
            }
        }
    }
}
