using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class CustomSectionController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public CustomSectionController(IUnitOfService unitOfService)
        {
           _unitOfService = unitOfService;
        }
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CustomSectionView customSection)
        {
            var id = HttpContext.Session.GetInt32("cvId");
            var cvId = (long)id;
            if (ModelState.IsValid)
            {
                try
                {
                  await _unitOfService.CustomSectionService.AddCustomSection(customSection, cvId);
                   await _unitOfService.CustomSectionService.Save();
                    return RedirectToAction("Index", "CustomSection");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(customSection);

                }
            }
            else
            {
                return View(customSection);
            }
        }
        public async Task<IActionResult> Update(long sectionId)
        {
            var section =await _unitOfService.CustomSectionService.GetSectionBySectionId(sectionId);
            return View(section);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomSectionView section)
        {
            if(ModelState.IsValid)
            {
                try
                {
                   await _unitOfService.CustomSectionService.UpdateCustomSection(section);
                   await  _unitOfService.CustomSectionService.Save();
                    return RedirectToAction("Index", "Cv");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(section);
                }
            }
            else { return View(section); }
        }
        public async Task<IActionResult> Delete(long sectionId)
        {
            await _unitOfService.CustomSectionService.DeleteCustomSection(sectionId);
            await _unitOfService.CustomSectionService.Save();
            return RedirectToAction("Index", "Cv");
        }
    }
}
