using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess
{
    public class Students
    {
        #region Propeties
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name")]
        public string StudentsName { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public string StudentsID { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string StudentsEmail { get; set; }

        [Required]
        public string Faculty { get; set; }

        
        [Required]
        [Display(Name = "Year")]
        public string StudyYear { get; set; }

        [Required]
        [Display(Name = "Semster")]
        public string StudySemester { get; set; }

        [Display(Name = "Start Date")]

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set;  }

        public bool FormI_1 { get; set; }

        public bool FormI_3 { get; set; }

        public bool FormI_5 { get; set; }

        public bool FormI_6 { get; set; }

        public bool FormI_7 { get; set; }

        [Display(Name ="VivaSheduledDate")]
        public DateTime? VivaSheduledDate { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

       
        [Display(Name = "contact number")]
        public int? CompanyPhoneNumber { get; set; }

        
        [MaxLength(255)]
        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }

        [ForeignKey("Instructors")]
        [Display(Name = "Instructor")]
        public int? InstructorID { get; set; }   

        public virtual Instructors Instructors { get; set; }

        #endregion
    }
}
