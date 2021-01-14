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
    using System.Web;

    public partial class HEmployee
    {
        public int HEmployeeID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }


        [Display(Name = "Joining Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Image")]
        public string ImagePath { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public HEmployee()
        {
            ImagePath = "~/AppFiles/Images/blnk3.jpg";
        }
    }
}