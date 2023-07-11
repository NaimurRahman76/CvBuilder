using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{
    public class SkillView:Default
    {
        [Required]
        public string Name { get; set; }
        [Range(1, 10,ErrorMessage ="Value needs to be in range 1 to 10")]
        public int Level { get; set; }
    }
}
