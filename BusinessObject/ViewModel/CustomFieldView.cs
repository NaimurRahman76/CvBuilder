
using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ViewModel
{
    public class CustomFieldView:Default
    {
        [NameValidation]
        public string FieldName { get; set; }
        [Required]
        public string FieldType { get; set; }
        public string? FieldValueString { get; set; }
        public string? FieldValueText { get; set; }
        public long? FieldValueNumber { get; set; }
        public DateTime? FieldValueDate { get; set; }
    }   
}
