

using BusinessObject.DataModel;
using BusinessObject.Validation;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DataModel
{
    public class CustomSection:Default
    {
        [Required]
        [NameValidation]
        public String SectionName { get; set; }

        public List<CustomField> CustomFieldList { get; set; }
        public Cv Cv { get; set; }
    }
}
