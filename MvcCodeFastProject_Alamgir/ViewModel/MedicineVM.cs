using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFastProject_Alamgir.ViewModel
{
    public class MedicineVM
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime PurchageDate { get; set; }
        public string ImagePath { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }


    }
}