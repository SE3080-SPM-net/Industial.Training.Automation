using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industial.Training.Automation.Models
{
    public class StudentDetailViewModel
    {
        public string StudentsName { get; set; }

        public string StudentsID { get; set; }

        public string Faculty { get; set; }

        public string StudyYear { get; set; }

        public string StudySemester { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string CompanyName { get; set; }

        public int CompanyPhoneNumber { get; set; }

        public string SupervisorName { get; set; }


    }
}