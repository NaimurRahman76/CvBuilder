using BusinessLogic.IServices;
using BusinessObject.ViewModel;
using CV_Maker.Utility;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class BasicInfoController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BasicInfoController( IUnitOfService unitOfService, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfService = unitOfService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var basicInfo = await _unitOfService.BasicInfoService.GetBasicInfoByCvId(cvId);
            return View(basicInfo);

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BasicInfoView basicInfo, IFormFile image)
        {
            if (image != null && image.Length != 0)
            {
                var extension = Path.GetExtension(image.FileName);
                var testImage = new Image();
                var check = testImage.Check(extension);
                if (!check) ModelState.AddModelError("Picture", "Invalid file please select a image file");
                else
                {
                    var imagePath = testImage.GetPath(image, extension);
                    basicInfo.Picture = imagePath;
                }
            }
            if (ModelState.IsValid)
            {
                var cvId = (long)HttpContext.Session.GetInt32("cvId");
                await _unitOfService.BasicInfoService.AddBasicInfo(basicInfo, cvId);
                await _unitOfService.BasicInfoService.Save();
                return RedirectToAction("Index", "BasicInfo");
            }
            else
            {
                if (image == null) ModelState.AddModelError("Picture", "Picture filed can't be empty");
                return View(basicInfo);
            }

        }
        public async Task<IActionResult> Delete(long basicInfoId)
        {
            var basicInfo =await _unitOfService.BasicInfoService.GetBasicInfoByBasicInfoId(basicInfoId);
            if (basicInfo != null)
            {
              
                  var imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, basicInfo.Picture);
                  Image.Delete(imageFolderPath);
                  await  _unitOfService.BasicInfoService.DeleteBasicInfo(basicInfoId);
                  await  _unitOfService.BasicInfoService.Save();
                  return RedirectToAction("Index", "BasicInfo");
            }
            else
            {
                throw new Exception("Invalid id");
            }
            
        }

        public async Task<IActionResult> Update(long basicInfoId)
        {
            var res =await _unitOfService.BasicInfoService.GetBasicInfoByBasicInfoId(basicInfoId);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BasicInfoView basicInfo, IFormFile? image)
        {
            if (image != null && image.Length != 0)
            {
                var extension = Path.GetExtension(image.FileName);
                var imageUtility = new Image();
                var check = imageUtility.Check(extension);
                if (!check) ModelState.AddModelError("Picture", "Invalid file please select a image file");
                else
                {
                    var imagePath = imageUtility.GetPath(image, extension);
                    basicInfo.Picture = imagePath;
                }
            }
            if (ModelState.IsValid)
            {
                var tempBasicInfo = await _unitOfService.BasicInfoService.GetBasicInfoByBasicInfoId(basicInfo.Id);
                if (basicInfo.Picture != null)
                {
                    if (tempBasicInfo != null) {
                        var path = Path.Combine(_webHostEnvironment.WebRootPath, tempBasicInfo.Picture);
                        Image.Delete(path);
                    }
                }
                else
                {
                    basicInfo.Picture = tempBasicInfo.Picture;
                }
                await _unitOfService.BasicInfoService.UpdateBasicInfo(basicInfo);
                await _unitOfService.BasicInfoService.Save();
                return RedirectToAction("Index", "BasicInfo");
            }
            else
            {
                return View(basicInfo);
            }

        }
    }
}
