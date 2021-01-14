using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFastProject_Alamgir.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Doctor Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PhoneNumber)]
        //[StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 character")]
        public string ContactNo { get; set; }


        [Display(Name = "Joining Date")]
         [DataType(DataType.DateTime)]
         //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: d}")]

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
       // [Display(Name = "Department Name")]
        //[Required(ErrorMessage = "This field is required")]
        //[StringLength(10, MinimumLength = 3, ErrorMessage = "Username must be 3-10 character")]
        //[Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Password not matched")]
        //[NotMapped]
        //public string ConfirmPassword { get; set; }

        //public string ImagePath { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase ImageFile { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}