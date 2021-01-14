using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCodeFastProject_Alamgir.Models
{
    [Table("MedicineCategory")]
    public class MedicineCategory
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, Display(Name = "Medicine Category")]
        public string Name { get; set; }

        public virtual IList<MedicineItem> MedicineItems { get; set; }
    }
}