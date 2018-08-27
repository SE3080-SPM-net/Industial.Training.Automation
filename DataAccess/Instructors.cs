using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Instructors
    {
        #region Propeties
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name")]
        public string InstructorName { get; set; }


        public virtual ICollection<Students> Students { get; set; }
        #endregion
    }
}
