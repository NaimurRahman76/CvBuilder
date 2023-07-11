

using BusinessObject.DataModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DataModel
{
    public class CustomField:Default
    {
        [Required]
        public string FieldName { get; set; }
        [Required]
        public string FieldType { get; set; }
        public string? FieldValueString { get; set; }
        public string? FieldValueText { get; set; }
        public long? FieldValueNumber { get; set; }
        public DateTime? FieldValueDate { get; set; }
        public CustomSection CustomSection { get; set; }
    }   
}
