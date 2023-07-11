using BusinessObject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class ExperienceValidation
    {
        public static List<Exception> Check(Experience experience)
        {
            var exceptions = new List<Exception>();
            if (experience.Company == null) exceptions.Add(new Exception("Comapny name can't be empty"));
            if (experience.Position == null) exceptions.Add(new Exception("Positon name can't be empty"));
            if (experience.Description == null) exceptions.Add(new Exception("Work description can't be empty"));
            if (experience.StartDate == DateTime.MinValue) exceptions.Add(new Exception("StartDate can't be empty"));
            if (experience.EndDate == DateTime.MinValue) exceptions.Add(new Exception("End date can't be empty"));
            return exceptions;
        }
    }
}
