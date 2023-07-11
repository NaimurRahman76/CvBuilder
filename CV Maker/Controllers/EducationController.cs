using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public EducationController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<IActionResult> Index()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var res =await _unitOfService.EducationService.GetAllEducationByCvId(cvId);
            return View(res);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(EducationView education)
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.EducationService.AddEducation(education, cvId);
                    await _unitOfService.EducationService.Save();
                    return RedirectToAction("Index", "Education");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(education);
                }
            }
            else
            {
                return View(education);
            }


        }
        public async Task<IActionResult> Update(long educationId)
        {
            var res =await _unitOfService.EducationService.GetEducationById(educationId);
            return View(res);
        }


        [HttpPost]
        public async Task<IActionResult> Update(EducationView education)
        {

            if(ModelState.IsValid)
            {
                try
                {

                    await _unitOfService.EducationService.UpdateEducation(education);
                    await _unitOfService.EducationService.Save();
                    return RedirectToAction("Index", "Education");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    education = await _unitOfService.EducationService.GetEducationById(education.Id);
                    return View(education);
                }
            }
            else
            {
                return View(education);
            }

        }

        public async Task<IActionResult> Delete(long educationId)
        {
           await _unitOfService.EducationService.DeleteEducationById(educationId);
            await _unitOfService.EducationService.Save();
            return RedirectToAction("Index", "Education");
        }
    }
}
