using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Validation
{
    internal class DateValidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Date can't be null");
            if(value is DateTime dateTime)
            {
                if (dateTime > DateTime.Now)
                {
                    return new ValidationResult("Date time is Ahead of current time");
                }
            }
            return ValidationResult.Success;
        }
    }
}
