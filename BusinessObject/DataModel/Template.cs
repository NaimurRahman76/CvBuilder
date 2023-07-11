using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DataModel
{
    public class Template:Default
    {
        [Required]
        public bool Experience { get; set; }
        [Required]
        public bool Project { get; set; }
    }
}
