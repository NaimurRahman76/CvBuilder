
using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DataModel
{
    public class User:Default
    {
        [Required]
        [NameValidation]
        public string Name { get; set; }
        [Required]
        [EmailValidation]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsEmailConfirmed { get; set; }=false;
        public int? ConfirmationCode { get; set; }
        public DateTime? Validity { get; set; }
        public List<Cv> CvList { get; set; }
    }
}
