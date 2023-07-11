using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DataModel
{
    public class Experience:Default
    {
        [Required]

        public string Company { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [DateValidation]
        public DateTime StartDate { get; set; }
        [Required]
        [DateValidation]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        public Cv Cv { get; set; }
    }
}
