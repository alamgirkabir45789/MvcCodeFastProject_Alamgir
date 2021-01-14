using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFastProject_Alamgir.Models
{
    public class OrderDetail
    {

        [Key]
        public Guid DetailId { get; set; }
        public Guid MasterId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public virtual OrderMaster OrderMaster { get; set; }
    }
}