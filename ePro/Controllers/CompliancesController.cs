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
    public class CompliancesController : Controller
    {
        private eProContext db = new eProContext();

        // GET: Compliances
        public ActionResult Index()
        {
            var compliance = db.Compliance.Include(c => c.ComplianceForm).Include(c => c.ComplianceItem);
            return View(compliance.ToList());
        }

        // GET: Compliances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compliance compliance = db.Compliance.Find(id);
            if (compliance == null)
            {
                return HttpNotFound();
            }
            return View(compliance);
        }

        // GET: Compliances/Create
        public ActionResult Create()
        {
            ViewBag.ComplianceFormID = new SelectList(db.ComplianceForm, "ComplianceFormID", "Name");
            ViewBag.ComplianceitemsID = new SelectList(db.ComplianceItems, "ComplianceItemsID", "ItemName");
            return View();
        }

        // POST: Compliances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplinanceID,ComplianceFormID,ComplianceitemsID,Description")] Compliance compliance)
        {
            if (ModelState.IsValid)
            {
                db.Compliance.Add(compliance);
                db.SaveChanges();
          


                return RedirectToAction("Index");
            }

            ViewBag.ComplianceFormID = new SelectList(db.ComplianceForm, "ComplianceFormID", "Name", compliance.ComplianceFormID);
            ViewBag.ComplianceitemsID = new SelectList(db.ComplianceItems, "ComplianceItemsID", "ItemName", compliance.ComplianceitemsID);
            return View(compliance);
        }

        // GET: Compliances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compliance compliance = db.Compliance.Find(id);
            if (compliance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplianceFormID = new SelectList(db.ComplianceForm, "ComplianceFormID", "Name", compliance.ComplianceFormID);
            ViewBag.ComplianceitemsID = new SelectList(db.ComplianceItems, "ComplianceItemsID", "ItemName", compliance.ComplianceitemsID);
            return View(compliance);
        }

        // POST: Compliances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplinanceID,ComplianceFormID,ComplianceitemsID,Description")] Compliance compliance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compliance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplianceFormID = new SelectList(db.ComplianceForm, "ComplianceFormID", "Name", compliance.ComplianceFormID);
            ViewBag.ComplianceitemsID = new SelectList(db.ComplianceItems, "ComplianceItemsID", "ItemName", compliance.ComplianceitemsID);
            return View(compliance);
        }

        // GET: Compliances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compliance compliance = db.Compliance.Find(id);
            if (compliance == null)
            {
                return HttpNotFound();
            }
            return View(compliance);
        }

        // POST: Compliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compliance compliance = db.Compliance.Find(id);
            db.Compliance.Remove(compliance);
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
