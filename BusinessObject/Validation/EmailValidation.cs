using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessObject.Validation
{
    public class EmailValidation:ValidationAttribute
    {
        private const string EmailRegexPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var email = value.ToString();
                if (Regex.IsMatch(email, EmailRegexPattern))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Invalid Email format");
                }
            }
            return new ValidationResult("Invalid email format");
        }
    }
}

