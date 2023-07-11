

using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DataModel
{
    public class Education:Default
    {
        [Required]
        [NameValidation]
        public string Degree { get; set; }
        [Required]
        public string Institution { get; set; }
        [Required]
        [DateValidation]
        public DateTime StartDate { get; set; }
        [Required]
        [DateValidation]
        public DateTime EndDate { get; set; }
        public Cv Cv { get; set; }  
    }
}
