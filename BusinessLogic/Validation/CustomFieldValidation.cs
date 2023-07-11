using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class CustomFieldValidation
    {
        public static List<Exception> Check(CustomField customField)
        {
            var exceptionList = new List<Exception>();
            if (customField == null) { exceptionList.Add(new Exception("CustomFiled can't be null")); }
            if (customField.FieldName == null) { exceptionList.Add(new Exception("FieldName can't be null/empty")); }
            if(customField.FieldType==null) { exceptionList.Add(new Exception("Field Type can't be null")); }
            if(customField.FieldValueDate==null&& customField.FieldValueText==null && customField.FieldValueNumber==null&& customField.FieldValueString == null)
            {
                exceptionList.Add(new Exception("Filed Value can't be Null/Empty"));
            }
            return exceptionList;
        }
    }
}
