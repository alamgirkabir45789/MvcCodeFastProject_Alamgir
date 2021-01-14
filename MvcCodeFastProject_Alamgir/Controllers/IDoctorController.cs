using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using MvcCodeFastProject_Alamgir.Models;

namespace MvcCodeFastProject_Alamgir.Controllers
{
    public class IDoctorController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        private ApplicationDbContext _db;
        public IDoctorController()
        {
            _db = new ApplicationDbContext();
        }

        public JsonResult List()
        {
            return Json(_db.InternDoctors.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(InternDoctor internDoctor)
        {
            _db.InternDoctors.Add(internDoctor);
            _db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_db.InternDoctors.FirstOrDefault(x => x.InternDoctorID == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(InternDoctor internDoctor)
        {
            var data = _db.InternDoctors.FirstOrDefault(x => x.InternDoctorID == internDoctor.InternDoctorID);
            if (data != null)
            {
                data.Name =internDoctor.Name;
                data.Address = internDoctor.Address;
                data.Email = internDoctor.Email;
                data.ContactNo = internDoctor.ContactNo;
                data.JoiningDate = internDoctor.JoiningDate;
                _db.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _db.InternDoctors.FirstOrDefault(x => x.InternDoctorID == ID);
            _db.InternDoctors.Remove(data);
            _db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}