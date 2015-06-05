using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ePro.DB;
using ePro.Models;

namespace ePro.Controllers
{
    public class ComplianceCategoriesController : Controller
    {
        private eProContext db = new eProContext();

        // GET: ComplianceCategories
        public ActionResult Index()
        {
            return View(db.ComplianceCategory.ToList());
        }

        // GET: ComplianceCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceCategory complianceCategory = db.ComplianceCategory.Find(id);
            if (complianceCategory == null)
            {
                return HttpNotFound();
            }
            return View(complianceCategory);
        }

        // GET: ComplianceCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplianceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplianceCategoryID,Name")] ComplianceCategory complianceCategory)
        {
            if (ModelState.IsValid)
            {
                db.ComplianceCategory.Add(complianceCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complianceCategory);
        }

        // GET: ComplianceCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceCategory complianceCategory = db.ComplianceCategory.Find(id);
            if (complianceCategory == null)
            {
                return HttpNotFound();
            }
            return View(complianceCategory);
        }

        // POST: ComplianceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplianceCategoryID,Name")] ComplianceCategory complianceCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complianceCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complianceCategory);
        }

        // GET: ComplianceCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceCategory complianceCategory = db.ComplianceCategory.Find(id);
            if (complianceCategory == null)
            {
                return HttpNotFound();
            }
            return View(complianceCategory);
        }

        // POST: ComplianceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplianceCategory complianceCategory = db.ComplianceCategory.Find(id);
            db.ComplianceCategory.Remove(complianceCategory);
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
