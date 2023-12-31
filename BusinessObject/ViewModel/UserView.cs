﻿using BusinessObject.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.ViewModel
{
    public class UserView:Default
    {
        [NameValidation]
        public string Name { get; set; }
        [EmailValidation]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
