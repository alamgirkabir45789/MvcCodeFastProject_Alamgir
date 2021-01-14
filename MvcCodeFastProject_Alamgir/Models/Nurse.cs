using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcCodeFastProject_Alamgir.Attirbutes.ValidationAttributes;


namespace MvcCodeFastProject_Alamgir.Models
{
    public class Nurse
    {

        public int NurseID { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string NurseName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [Today(ErrorMessage ="Joining date must be Today")]
        public DateTime JoiningDate { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}