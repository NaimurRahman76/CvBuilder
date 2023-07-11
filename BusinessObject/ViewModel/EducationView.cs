
using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{
    public class EducationView:Default
    {

        [Required]
        public string Degree { get; set; }
        [Required]
        public string Institution { get; set; }
        [Required]
        [DateValidation]
        public DateTime StartDate { get; set; }
        [DateValidation]
        public DateTime EndDate { get; set; }
    }
}
