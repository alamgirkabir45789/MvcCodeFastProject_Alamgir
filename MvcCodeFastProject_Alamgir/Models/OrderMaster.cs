using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFastProject_Alamgir.Models
{
    public class OrderMaster
    {

        [Key]
        public Guid MasterId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}