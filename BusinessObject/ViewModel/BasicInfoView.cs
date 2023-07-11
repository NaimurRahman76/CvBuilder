

using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{
    public class BasicInfoView:Default
    {
        [NameValidation]
        public string FullName { get; set; }
        public string ?Picture { get; set; }
        [Required]
        [MaxLength(500)]
        public string Biography { get; set; }
        [EmailValidation]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
