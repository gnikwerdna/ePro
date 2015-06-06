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
    public class ComplianceItemsController : Controller
    {
        private eProContext db = new eProContext();

        // GET: ComplianceItems
        public ActionResult Index()
        {
            return View(db.ComplianceItems.ToList());
        }

        // GET: ComplianceItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceItems complianceItems = db.ComplianceItems.Find(id);
            if (complianceItems == null)
            {
                return HttpNotFound();
            }
            return View(complianceItems);
        }

        // GET: ComplianceItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplianceItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplianceItemsID,ItemName")] ComplianceItems complianceItems)
        {
            if (ModelState.IsValid)
            {
                db.ComplianceItems.Add(complianceItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complianceItems);
        }

        // GET: ComplianceItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceItems complianceItems = db.ComplianceItems.Find(id);
            if (complianceItems == null)
            {
                return HttpNotFound();
            }
            return View(complianceItems);
        }

        // POST: ComplianceItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplianceItemsID,ItemName")] ComplianceItems complianceItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complianceItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complianceItems);
        }

        // GET: ComplianceItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceItems complianceItems = db.ComplianceItems.Find(id);
            if (complianceItems == null)
            {
                return HttpNotFound();
            }
            return View(complianceItems);
        }

        // POST: ComplianceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplianceItems complianceItems = db.ComplianceItems.Find(id);
            db.ComplianceItems.Remove(complianceItems);
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
