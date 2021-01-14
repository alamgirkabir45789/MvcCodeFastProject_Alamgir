using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFastProject_Alamgir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}