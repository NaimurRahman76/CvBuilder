using BusinessLogic.IServices;
using BusinessObject.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.ViewComponents
{
    public class CustomSectionListViewComponent : ViewComponent
    {
        private readonly IUnitOfService _unitOfService;
        public CustomSectionListViewComponent(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var customSections = await _unitOfService.CustomSectionService.GetAllCustomSectionByCvIdAsync(cvId);
            return View(customSections);
        }
    }
}
