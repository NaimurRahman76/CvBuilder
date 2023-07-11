using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessObject.Validation
{
    internal class NameValidation:ValidationAttribute
    {
        private static readonly string NamePattern = @"^[a-zA-Z\s.'-]+$";


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var name=value.ToString();
                if (name.Length > 25)
                {
                    return new ValidationResult("Name can't be more than 25 char");
                }
                if(Regex.IsMatch(name, NamePattern))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"{name} is not a valid name.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
