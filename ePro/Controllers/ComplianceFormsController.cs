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
using System.Data.Entity.Infrastructure;

namespace ePro.Controllers
{
    public class ComplianceFormsController : Controller
    {
        private eProContext db = new eProContext();

        // GET: ComplianceForms
        public ActionResult Index(int? SelectedCompCat)
        {

            var compliancecategory = db.ComplianceCategory.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedCompCat = new SelectList(compliancecategory, "ComplianceCategoryID", "Name", SelectedCompCat);
            int ComplianceCategoryID = SelectedCompCat.GetValueOrDefault();


            IQueryable<ComplianceForm> complianceforms = db.ComplianceForm
              .Where(c => !SelectedCompCat.HasValue || c.ComplianceCategoryID == ComplianceCategoryID)
              .OrderBy(d => d.ComplianceFormID)
              .Include(d => d.ComplianceCategory);
            var sql = complianceforms.ToString();
            return View(complianceforms.ToList());

            // return View(db.ComplianceCategory.ToList());
        }

        // GET: ComplianceForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceForm complianceForm = db.ComplianceForm.Find(id);
            if (complianceForm == null)
            {
                return HttpNotFound();
            }
            return View(complianceForm);
        }

        // GET: ComplianceForms/Create
        public ActionResult Create()
        {
            ViewBag.ComplianceCategoryID = new SelectList(db.ComplianceCategory, "ComplianceCategoryID", "Name");
            //PopulateComplianceCategoryDropDownList();
            return View();
        }
        private void PopulateComplianceCategoryDropDownList(object selectedCompCat = null)
        {
            var CompCatQuery = from d in db.ComplianceCategory
                               orderby d.Name
                               select d;
            ViewBag.ComplianceCategoryID = new SelectList(CompCatQuery, "ComplianceCategroyID", "Name", selectedCompCat);
        }

        // POST: ComplianceForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplianceFormID,Name,ComplianceCategoryID")] ComplianceForm complianceForm)
        {
            if (ModelState.IsValid)
            {
                db.ComplianceForm.Add(complianceForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplianceCategoryID = new SelectList(db.ComplianceCategory, "ComplianceCategoryID", "Name", complianceForm.ComplianceCategoryID);
            return View(complianceForm);
        }

        // GET: ComplianceForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceForm complianceForm = db.ComplianceForm.Find(id);
            if (complianceForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplianceCategoryID = new SelectList(db.ComplianceCategory, "ComplianceCategoryID", "Name", complianceForm.ComplianceCategoryID);
            return View(complianceForm);
        }

        // POST: ComplianceForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public ActionResult Edit([Bind(Include = "ComplianceFormID,Name,ComplianceCategoryID")] ComplianceForm complianceForm)
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var complianceformToUpdate = db.ComplianceForm.Find(id);
            if (TryUpdateModel(complianceformToUpdate, "", new string[] { "ComplianceFormID,Name,ProductID" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateComplianceCategoryDropDownList(complianceformToUpdate.ComplianceFormID);
            return View(complianceformToUpdate);
        }

        // GET: ComplianceForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplianceForm complianceForm = db.ComplianceForm.Find(id);
            if (complianceForm == null)
            {
                return HttpNotFound();
            }
            return View(complianceForm);
        }

        // POST: ComplianceForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplianceForm complianceForm = db.ComplianceForm.Find(id);
            db.ComplianceForm.Remove(complianceForm);
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
