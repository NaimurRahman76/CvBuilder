using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class Projectvalidation
    {
        public static List<Exception> Check(ProjelctView project)
        {
            var errors = new List<Exception>();
            if (project.Name == null) errors.Add(new Exception("Project Name can't be null"));
            if (project.Role == null) errors.Add(new Exception("Your Role can't be null"));
            if (project.Technology == null) errors.Add(new Exception("Project Technology can't be null"));
            if (project.Description == null) errors.Add(new Exception("Project description can't be null"));
            if (project.StartDate == DateTime.MinValue) errors.Add(new Exception("Project startdate can't be null"));
            if (project.EndDate == DateTime.MinValue) errors.Add(new Exception("Project end date can't be null"));
            return errors;
        }
    }
}
