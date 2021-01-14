using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCodeFastProject_Alamgir.Models;
using MvcCodeFastProject_Alamgir.ViewModel;
using PagedList;

namespace ViewModelInMvc.Controllers
{
    [RoutePrefix("Medicine Info")]
    public class MedicineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Medicine
        [Route("Home")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var medicines = from t in db.Medicines
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                medicines = medicines.Where(t => t.MedicineName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    medicines = medicines.OrderByDescending(t => t.MedicineName);
                    break;
                default:
                    medicines = medicines.OrderBy(t => t.MedicineName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(medicines.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicineVM medicineVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(medicineVM.ImageFile.FileName);
                string extention = Path.GetExtension(medicineVM.ImageFile.FileName);
                HttpPostedFileBase postedFile = medicineVM.ImageFile;
                int length = postedFile.ContentLength;

                if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extention;
                        medicineVM.ImagePath = "~/AppFiles/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                        medicineVM.ImageFile.SaveAs(fileName);
                        var medicine = Mapper.Map<Medicine>(medicineVM);

                        db.Medicines.Add(medicine);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {

                            ModelState.Clear();
                            return RedirectToAction("Index", "Medicine");
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

        public ActionResult Edit(int? id)
        {
            var query = db.Medicines.Single(t => t.MedicineID == id);
            Session["Image"] = query.ImagePath;

            var medicine = Mapper.Map<Medicine, MedicineVM>(query);
            return View(medicine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicineVM medicineVM)
        {

            if (ModelState.IsValid == true)
            {
                if (medicineVM.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(medicineVM.ImageFile.FileName);
                    string extention = Path.GetExtension(medicineVM.ImageFile.FileName);
                    HttpPostedFileBase postedFile = medicineVM.ImageFile;
                    int length = postedFile.ContentLength;
                    if (extention.ToLower() == ".jpg" || extention.ToLower() == ".jpeg" || extention.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extention;
                            medicineVM.ImagePath = "~/AppFiles/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName);
                            medicineVM.ImageFile.SaveAs(fileName);

                            var product = Mapper.Map<Medicine>(medicineVM);


                            db.Entry(product).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                ModelState.Clear();
                                return RedirectToAction("Index", "Medicine");
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
                    medicineVM.ImagePath = Session["Image"].ToString();
                    var product = Mapper.Map<Medicine>(medicineVM);

                    db.Entry(product).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Medicine");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data not Updated')</script>";
                    }
                }
            }
            return View();


        }


        public ActionResult Delete(int? id)
        {
            var query = db.Medicines.Single(t => t.MedicineID == id);
            var medicine = Mapper.Map<Medicine, MedicineVM>(query);
            return View(medicine);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, MedicineVM medicineVM)
        {
            var query = db.Medicines.Single(t => t.MedicineID == id);
            var trainee = Mapper.Map<Medicine, MedicineVM>(query);
            db.Medicines.Remove(query);  // 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

