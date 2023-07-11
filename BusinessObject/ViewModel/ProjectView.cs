using BusinessObject.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.ViewModel
{
    public class ProjectView:Default
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string  Technology { get; set; }
        [Required]
        public string Role { get; set; }
        [DateValidation]
        public DateTime StartDate { get; set; }
        [DateValidation]
        public DateTime EndDate { get; set; }
    }
}
