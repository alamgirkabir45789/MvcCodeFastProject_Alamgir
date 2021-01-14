using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.IO;
using MvcCodeFastProject_Alamgir.Models;
using System.Data.Entity;

namespace MvcCodeFastProject_Alamgir.Controllers
{
    public class HEmployeeController : Controller
    {

        // GET: HEmployee
        public ActionResult Index()
        {
            return View();

        }
          
        public ActionResult ViewAll()
        {
           
            return View(GetAllEmployee());
        }

        IEnumerable<HEmployee> GetAllEmployee()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.HEmployees.ToList<HEmployee>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            HEmployee emp = new HEmployee();
            if (id != 0)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    emp = db.HEmployees.Where(x => x.HEmployeeID == id).FirstOrDefault<HEmployee>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(HEmployee emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    if (emp.HEmployeeID == 0)
                    {
                        db.HEmployees.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    HEmployee emp = db.HEmployees.Where(x => x.HEmployeeID == id).FirstOrDefault<HEmployee>();
                    db.HEmployees.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}