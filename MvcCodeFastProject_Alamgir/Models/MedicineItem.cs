using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcCodeFastProject_Alamgir.Attirbutes.ValidationAttributes;

namespace MvcCodeFastProject_Alamgir.Models
{
    public class MedicineItem
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required, Display(Name = "Medicine Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Required, Today, DataType(DataType.Date), Column(TypeName = "date"), Display(Name = "Issue Date")]
 
        public DateTime EntryDate { get; set; }

        [Required]
        public long Quantity { get; set; }

        [ForeignKey("MedicineCategory")]
        public long MedicineCategoryID { get; set; }

        public virtual MedicineCategory MedicineCategory { get; set; }
    }
}