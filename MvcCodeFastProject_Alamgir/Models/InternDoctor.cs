using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFastProject_Alamgir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class InternDoctor
    {
        public int InternDoctorID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ContactNo { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.DateTime)]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: d}")]
        // [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
    }
}