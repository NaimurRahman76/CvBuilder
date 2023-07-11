using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{
    public class ExperienceView:Default
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Position { get; set; }
        [DateValidation]
        public DateTime StartDate { get; set; }
        [DateValidation]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
