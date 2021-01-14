using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFastProject_Alamgir.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.OrderDetails = new List<OrderDetailsViewModel>();
        }

        public Guid MasterId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
    }


    public class OrderDetailsViewModel
    {
        public Guid DetailId { get; set; }
        public Guid MasterId { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }

    }
}