using BusinessLogic.IServices;
using BusinessObject.DataModel;
using BusinessObject.ViewModel;
using CV_Maker.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class CustomFieldController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        private readonly Session _session;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomFieldController(Session session, IUnitOfService unitOfService,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfService = unitOfService;
            _session = session;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(long sectionId = 0, string sectionName = "")
        {

            if (sectionId != null && sectionId > 0)
            {
                HttpContext.Session.SetInt32("sectionId", (int)sectionId);
                HttpContext.Session.SetString("sectionName", sectionName);
            }
            else
            {
                sectionId = (long)HttpContext.Session.GetInt32("sectionId");
            }
            var list = await _unitOfService.CustomFieldService.GetAllCustomFieldBySectionId(sectionId);
            return View(list);
        }
        public async  Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(CustomFieldView customField, IFormFile image)
        {
            // customField.FilePath = "Empty";
            //ModelState.Clear();
            ModelState.Remove("image");
            if (image != null && image.Length > 0)
            {
                var extension = Path.GetExtension(image.FileName);
                var result = new Image().Check(extension);
                if (result == false)
                {
                    ModelState.AddModelError("FieldValueString", "please select an image file");
                    return View(customField);
                }
                else
                {
                    var imagePath = new Image().GetPath(image, extension);
                    customField.FieldValueString = imagePath;
                }
            }
            var sectionId = _session.GetSectionId();
            if (!ModelState.IsValid)
            {
                
                return View(customField);
            }
            try
            {
                    await _unitOfService.CustomFieldService.AddCustomField(customField, sectionId);
                    await _unitOfService.CustomFieldService.Save();

                    return RedirectToAction("Index", "CustomField");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FieldValue", "Field Can't be null");
                return View(customField);
            }
           
        }

        public async Task<IActionResult> Delete(long fieldId)
        {
            //System.IO.File.Delete("C:\\Users\\bs780\\Desktop\\Final Project\\CV Maker\\wwwroot\\images\\f7867efc-659e-43d6-875b-b589e06db2f8.png");
            var field =await _unitOfService.CustomFieldService.GetCustomFieldByFieldId(fieldId);
            if (field.FieldType == "file")
            {
                var imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, field.FieldValueString);
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
            }
           await _unitOfService.CustomFieldService.DeleteCustomField(fieldId);

           await _unitOfService.CustomFieldService.Save();
            return RedirectToAction("Index", "CustomField");
        }
        public async Task<IActionResult> Update(long fieldId)
        {
            ModelState.Clear();
            var field = await _unitOfService.CustomFieldService.GetCustomFieldByFieldId(fieldId);
            return View(field);
        }




        [HttpPost]
        public async Task<IActionResult> Update(CustomFieldView field, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var extension = Path.GetExtension(image.FileName);
                var result = new Image().Check(extension);
                if (result == false)
                {
                    ModelState.AddModelError("FieldValueString", "Please select an image file");
                    return View(field);
                }
                else
                {
                    var imagePath = new Image().GetPath(image, extension);
                    field.FieldValueString = imagePath;
                }
            }
            else
            {
                ModelState.Remove("image");
            }
            if(ModelState.IsValid)
            {
                    try
                    {
                        await  _unitOfService.CustomFieldService.UpdateCustomField(field);
                        await  _unitOfService.CustomFieldService.Save();
                        var sectionId = _session.GetSectionId();
                        var sectionName = _session.SectionName();
                        return RedirectToAction("Index", "CustomField", new { sectionId, sectionName });
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("error", "Update failed");
                        return View(field);
                    }
            }
            else
            {
                return View(field);
            }
            
           
        }
    }
}
