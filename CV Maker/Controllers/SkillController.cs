using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public SkillController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<IActionResult> Index()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var skillList = await _unitOfService.SkillService.GetAllSkillByCvId(cvId);
            return View(skillList);
        }
        public IActionResult Add()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(SkillView skill)
        {

            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.SkillService.AddSkill(skill, cvId);
                    await _unitOfService.SkillService.Save();
                    return RedirectToAction("Index", "Skill");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                    return View(skill);
                }
            }
            else
            {
                return View(skill);
            }

        }
        public async Task<IActionResult> Delete(long skillId)
        {
            try
            {
                await _unitOfService.SkillService.DeleteSkillById(skillId);
                await _unitOfService.SkillService.Save();
                return RedirectToAction("Index", "Skill");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Skill Id is invalid");
                return View();
            }
           
        }
        public async Task<IActionResult> Update(long skillId)
        {

            try
            {
                var tempSkill = await _unitOfService.SkillService.GetSkillById(skillId);
                return View(tempSkill);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Invalid skillId");
                return View();
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Update(SkillView skill)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _unitOfService.SkillService.UpdateSkill(skill);
                    await _unitOfService.SkillService.Save();
                    return RedirectToAction("Index", "Skill");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("exception", ex.Message);
                    return View(skill);
                }
            }
            else
            {
                return View(skill);
            }
        }

    }
}
