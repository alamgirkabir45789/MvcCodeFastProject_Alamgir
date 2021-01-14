using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCodeFastProject_Alamgir.Models;

namespace MvcCodeFastProject_Alamgir.Controllers
{
    public class LabExamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LabExam
        public ActionResult Index()
        {
            var labExams = db.LabExams.Include(l => l.Patient);
            return View(labExams.ToList());
        }

      


        // GET: LabExam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabExam labExam = db.LabExams.Find(id);
            if (labExam == null)
            {
                return HttpNotFound();
            }
            return View(labExam);
        }

        // GET: LabExam/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.patients, "PatientID", "Name");
            return View();
        }

        // POST: LabExam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabExamID,ExamName,PatientID,ExamDate,Price,VisitPrice,Total")] LabExam labExam)
        {
            if (ModelState.IsValid)
            {
                db.LabExams.Add(labExam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.patients, "PatientID", "Name", labExam.PatientID);
            return View(labExam);
        }

        // GET: LabExam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabExam labExam = db.LabExams.Find(id);
            if (labExam == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.patients, "PatientID", "Name", labExam.PatientID);
            return View(labExam);
        }

        // POST: LabExam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabExamID,ExamName,PatientID,ExamDate,Price,VisitPrice,Total")] LabExam labExam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labExam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.patients, "PatientID", "Name", labExam.PatientID);
            return View(labExam);
        }

        // GET: LabExam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabExam labExam = db.LabExams.Find(id);
            if (labExam == null)
            {
                return HttpNotFound();
            }
            return View(labExam);
        }

        // POST: LabExam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabExam labExam = db.LabExams.Find(id);
            db.LabExams.Remove(labExam);
            db.SaveChanges();
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
