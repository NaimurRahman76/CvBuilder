
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{

    public class CvView :Default
    {
        [Required]
        public string CvName { get; set; }
        [Required]
        public string CvType { get; set; }
    }
}
