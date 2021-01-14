using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MvcCodeFastProject_Alamgir.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int Amount { get; set; }
        
        public DateTime PaymentDate { get; set; }


    }
}