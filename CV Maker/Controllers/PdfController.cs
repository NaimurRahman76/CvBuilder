using BusinessLogic.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class PdfController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public PdfController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService; 
        }
        public async Task<IActionResult> Index()
        {
            var hasValue = HttpContext.Session.GetInt32("cvId").HasValue;
            if(hasValue)
            {
                var cvId = (long)HttpContext.Session.GetInt32("cvId");
                var cv = await _unitOfService.CvService.GetFullCvByCvId(cvId);
                return View(cv);
            }
            return View(null);
        }
    }
}
