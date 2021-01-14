using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCodeFastProject_Alamgir.CustomValidation;

namespace MvcCodeFastProject_Alamgir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MvcCodeFastProject_Alamgir.CustomValidation;
    public partial class Patient
    {
      
        [Key]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Patient Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Age { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 character")]
        public string ContactNo { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Appointment Date")]

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [FutureDateAttribute(ErrorMessage ="Date must not less than or equal Today")]
        //[FutureDateAttribute(ErrorMessage = "Appointment Date must be greater than or equal to Today's Date")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<LabExam> LabExams { get; set; }
    }
}