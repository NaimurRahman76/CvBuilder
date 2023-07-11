using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.DataModel
{
    public class BasicInfo : Default
    {
        [Required]
        [NameValidation]
        public string FullName { get; set; }
        public string? Picture { get; set; }
        [Required]
        [MaxLength(500)]
        public string Biography { get; set; }
        [Required]
        [EmailValidation]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        public long CvId { get; set; }
        public Cv Cv { get; set; }

    }
}
