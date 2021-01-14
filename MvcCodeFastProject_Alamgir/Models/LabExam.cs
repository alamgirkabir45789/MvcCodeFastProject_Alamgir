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

    public partial class LabExam
    {
        public int LabExamID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }
        [Required(ErrorMessage = "This field is required")]


        public int PatientID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Exam Date")]
       // [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExamDate { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public int Price { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public int VisitPrice { get; set; }

        [Display(Name = "Total Price")]
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Total { get { return (Price + VisitPrice); } }


        public virtual Patient Patient { get; set; }
    }
}