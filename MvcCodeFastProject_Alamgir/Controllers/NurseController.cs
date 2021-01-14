using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.IO;
using MvcCodeFastProject_Alamgir.Models;

namespace MvcCodeFastProject_Alamgir.Controllers
{
    public class NurseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            var data = db.Nurses.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Nurse nr)
        {
            if (ModelState.IsValid == true)
            {
                string fileName = Path.GetFileNameWithoutExtension(nr.ImageFile.FileName);
                string extention = Path.GetExtension(nr.ImageFile.FileName);
                HttpPostedFileBase postedFile = nr.ImageFile;
                int length = postedFile.ContentLength;
                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extention;
                        nr.ImagePath = "~/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        nr.ImageFile.SaveAs(fileName);
                        db.Nurses.Add(nr);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {

                            ModelState.Clear();
                            return RedirectToAction("Index", "Nurse");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data not inserted')</script>";
                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                    }
                }
                else
                {
                    TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var TraineeRow = db.Nurses.Where(model => model.NurseID == id).FirstOrDefault();
            Session["Image"] = TraineeRow.ImagePath;
            return View(TraineeRow);
        }

        [HttpPost]
        public ActionResult Edit(Nurse nr)
        {
            if (ModelState.IsValid == true)
            {
                if (nr.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(nr.ImageFile.FileName);
                    string extention = Path.GetExtension(nr.ImageFile.FileName);
                    HttpPostedFileBase postedFile = nr.ImageFile;
                    int length = postedFile.ContentLength;
                    if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extention;
                            nr.ImagePath = "~/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                            nr.ImageFile.SaveAs(fileName);
                            db.Entry(nr).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                ModelState.Clear();
                                return RedirectToAction("Index", "Nurse");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should Less Than 1 MB')</script>";
                        }
                    }
                    else
                    {
                        TempData["ExtentionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }
                }
                else
                {
                    nr.ImagePath = Session["Image"].ToString();
                    db.Entry(nr).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Nurse");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                    }
                }
            }
            return View();
        }


        public ActionResult Delete(int id = 0)
        {
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();

            }
            return View(nurse);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id = 0)
        {
            Nurse nurse = db.Nurses.Find(id);
            db.Nurses.Remove(nurse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}