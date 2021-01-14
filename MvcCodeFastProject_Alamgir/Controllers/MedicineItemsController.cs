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
    public class MedicineItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create(long? id)
        {
            if (id == null)
            {
                ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name");
            }
            else
            {
                ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name", id);
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Description,EntryDate,Quantity,MedicineCategoryID")] MedicineItem item, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // To save a image to a folder
                    string picture = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
                    file.SaveAs(path);

                    // To store as byte[] in a Table of Database
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        item.Image = ms.GetBuffer();
                    }
                    db.MedicineItems.Add(item);
                    await db.SaveChangesAsync();
                    TempData["id"] = item.MedicineCategoryID;
                    return RedirectToAction("Index", "MedicineCategories");
                }
                else
                {
                    ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name", item.MedicineCategoryID);
                    return PartialView(item);
                }
            }
            ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name", item.MedicineCategoryID);
            return PartialView(item);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineItem item = await db.MedicineItems.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name", item.MedicineCategoryID);
            return PartialView(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,Image,EntryDate,Quantity,MedicineCategoryID")] MedicineItem item, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // To save a image to a folder
                    string picture = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
                    file.SaveAs(path);

                    // To store as byte[] in a Table of Database
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        item.Image = ms.GetBuffer();
                    }
                }
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["id"] = item.MedicineCategoryID;
                return RedirectToAction("Index", "MedicineCategories");
            }
            ViewBag.MedicineCategoryID = new SelectList(db.MedicineCategories, "ID", "Name", item.MedicineCategoryID);
            return PartialView(item);
        }

        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineItem item = await db.MedicineItems.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return PartialView(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            MedicineItem item = await db.MedicineItems.FindAsync(id);
            db.MedicineItems.Remove(item);
            await db.SaveChangesAsync();
            TempData["id"] = item.MedicineCategoryID;
            return RedirectToAction("Index", "MedicineCategories");
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
