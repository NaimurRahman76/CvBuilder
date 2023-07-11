using BusinessObject.DataModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DataModel
{
    public class Skill:Default
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,10, ErrorMessage="value must be between 1 to 10")]
        public int Level { get; set; }
        public Cv Cv { get; set; }
    }
}
