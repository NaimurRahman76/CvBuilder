using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using CV_Maker.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        private readonly Session _session;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IUnitOfService unitOfService, Session session, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfService = unitOfService;
            _session = session;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _unitOfService.CvService.GetAllCvByUserId(1);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string CvTitle, string CvType)
        {
            var newCv = new CvView
            {
                CvName = CvTitle,
                CvType = CvType,
            };
            try
            {
                var userId =(long) HttpContext.Session.GetInt32("userId");
                await _unitOfService.CvService.AddCv(newCv, userId);
                await _unitOfService.CvService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return View();
               
            }
        }
        public async Task<IActionResult> Delete(long cvId)
        {
            var basicInfo=await _unitOfService.BasicInfoService.GetBasicInfoByCvId(cvId);
            var imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, basicInfo.Picture);
            try
            {
                if (System.IO.File.Exists(imageFolderPath))
                {
                    System.IO.File.Delete(imageFolderPath);
                }
                else
                {
                    throw new Exception("Picture not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the picture: {ex.Message}");
            }
            await _unitOfService.CvService.DeleteCv(cvId);
            await _unitOfService.CvService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string CvName, string CvType, long cvId)
        {

            var cv = new CvView
            {
                CvName = CvName,
                CvType = CvType,
                Id = cvId,
            };
            await _unitOfService.CvService.UpdateCv(cv);
            await _unitOfService.CvService.Save();
            return RedirectToAction("Index");
        }
    }
}