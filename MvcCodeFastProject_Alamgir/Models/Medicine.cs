using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFastProject_Alamgir.Models
{
    public partial class Medicine
    {
        public int MedicineID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string MedicineName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Price { get; set; }
        public string Description { get; set; }
        [Display(Name = "Purchage Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchageDate { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}

 