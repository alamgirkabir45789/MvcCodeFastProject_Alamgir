using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFastProject_Alamgir.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}