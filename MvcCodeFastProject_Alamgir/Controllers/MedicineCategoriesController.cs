using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCodeFastProject_Alamgir.Models;
using System.IO;

namespace MvcCodeFastProject_Alamgir.Controllers
{
    public class MedicineCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name");
            return View(await db.MedicineCategories.ToListAsync());
        }

        public ActionResult GetCategoryWiseItems(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["id"] = id;
            List<MedicineItem> medicineItems = db.MedicineItems.Where(e => e.MedicineCategoryID == id).ToList();

            if (medicineItems == null)
            {
                return HttpNotFound();
            }

            return PartialView("CategoryWiseItems", medicineItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MedicineItems")] MedicineCategory medicineCategory, HttpPostedFileBase[] Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Image != null)
                    {
                        if (medicineCategory.MedicineItems.Count == Image.Count())
                        {
                            for (int i = 0; i < medicineCategory.MedicineItems.Count; i++)
                            {
                                // To save a image to a folder
                                string picture = System.IO.Path.GetFileName(Image[i].FileName);
                                string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
                                Image[i].SaveAs(path);

                                // To store as byte[] in a Table of Database
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Image[i].InputStream.CopyTo(ms);
                                    medicineCategory.MedicineItems[i].Image = ms.GetBuffer();
                                }
                            }
                        }
                        db.MedicineCategories.Add(medicineCategory);
                        db.SaveChanges();
                        TempData["id"] = medicineCategory.ID;
                        return RedirectToAction("Index");
                    }
                }
                return View(medicineCategory);
            }
            catch (Exception)
            {
                return View(medicineCategory);
            }
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineCategory medicineCategory = await db.MedicineCategories.FindAsync(id);
            if (medicineCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name", id);
            return PartialView(medicineCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,MedicineItems")] MedicineCategory medicineCategory, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    for (int i = 0; i < medicineCategory.MedicineItems.Count; i++)
                    {
                        if (file[i] != null)
                        {
                            // To save a image to a folder
                            string picture = System.IO.Path.GetFileName(file[i].FileName);
                            string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
                            file[i].SaveAs(path);

                            // To store as byte[] in a Table of Database
                            using (MemoryStream ms = new MemoryStream())
                            {
                                file[i].InputStream.CopyTo(ms);
                                medicineCategory.MedicineItems[i].Image = ms.GetBuffer();
                            }
                        }
                    }
                }
                db.Entry(medicineCategory).State = EntityState.Modified;
                foreach(MedicineItem item in medicineCategory.MedicineItems)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                TempData["id"] = medicineCategory.ID;
                return RedirectToAction("Index");
            }
            return View(medicineCategory);
        }

        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineCategory medicineCategory = await db.MedicineCategories.FindAsync(id);
            if (medicineCategory == null)
            {
                return HttpNotFound();
            }
            return PartialView(medicineCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            MedicineCategory medicineCategory = await db.MedicineCategories.FindAsync(id);
            db.MedicineCategories.Remove(medicineCategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
