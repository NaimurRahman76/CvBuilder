

using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{
    public class CustomSectionView:Default
    {
        [Required]
        public String SectionName { get; set; }
    }
}
