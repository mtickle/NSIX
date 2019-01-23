using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSIX.DAL;
using NSIX.Models;

namespace NSIX.Controllers
{
    public class ExternalSARController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: ExternalSAR
        public async Task<ActionResult> Index()
        {
            var sarActivities = db.SarActivities.Include(s => s.TargetSectorCodeSimpleType).Include(s => s.TipDomainCodeSimpleType).Include(s => s.State).Include(s => s.SuspiciousActivityCodeSimpleType).Include(s => s.TipClassCodeSimpleType);
            return View(await sarActivities.ToListAsync());
        }

        // GET: ExternalSAR/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAR sAR = await db.SarActivities.FindAsync(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }
            return View(sAR);
        }

        // GET: ExternalSAR/Create
        public ActionResult Create()
        {
            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "FacetValue");
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "FacetValue");
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name");
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "FacetValue");
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "FacetValue");
            return View();
        }

        // POST: ExternalSAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ActivityDate,ActivityTime,Location,Address,City,StateAbbrev,ZipCode,Description,SuspiciousActivityCodeSimpleTypeID,TargetSectorCodeSimpleTypeID,TipClassCodeSimpleTypeID,TipDomainCodeSimpleTypeID,CreatedByName,CreatedByID,CreatedDate,UpdatedByName,UpdatedByID,UpdatedDate")] SAR sAR)
        {
            if (ModelState.IsValid)
            {

                sAR.CreatedByID = "External Tip";
                sAR.CreatedByName = "External Tip";
                sAR.CreatedDate = DateTime.Now;
                                
                sAR.FullAddress = sAR.Address + ", " + sAR.City + ", " + sAR.StateAbbrev + " " + sAR.ZipCode;

                db.SarActivities.Add(sAR);
                await db.SaveChangesAsync();
                //--- Here is where we can send them elsewhere.
                return RedirectToAction("ThankYou");
                //return RedirectToAction("Index");
            }

            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "FacetValue", sAR.TargetSectorCodeSimpleTypeID);
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "FacetValue", sAR.TipDomainCodeSimpleTypeID);
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", sAR.StateAbbrev);
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "FacetValue", sAR.SuspiciousActivityCodeSimpleTypeID);
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "FacetValue", sAR.TipClassCodeSimpleTypeID);
            return View(sAR);
        }


        public ActionResult ThankYou()
        {
            return View();
        }

        // GET: ExternalSAR/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAR sAR = await db.SarActivities.FindAsync(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "FacetValue", sAR.TargetSectorCodeSimpleTypeID);
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "FacetValue", sAR.TipDomainCodeSimpleTypeID);
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", sAR.StateAbbrev);
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "FacetValue", sAR.SuspiciousActivityCodeSimpleTypeID);
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "FacetValue", sAR.TipClassCodeSimpleTypeID);
            return View(sAR);
        }

        // POST: ExternalSAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ActivityDate,ActivityTime,Location,Address,City,StateAbbrev,ZipCode,Description,SuspiciousActivityCodeSimpleTypeID,TargetSectorCodeSimpleTypeID,TipClassCodeSimpleTypeID,TipDomainCodeSimpleTypeID,CreatedByName,CreatedByID,CreatedDate,UpdatedByName,UpdatedByID,UpdatedDate")] SAR sAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "FacetValue", sAR.TargetSectorCodeSimpleTypeID);
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "FacetValue", sAR.TipDomainCodeSimpleTypeID);
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", sAR.StateAbbrev);
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "FacetValue", sAR.SuspiciousActivityCodeSimpleTypeID);
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "FacetValue", sAR.TipClassCodeSimpleTypeID);
            return View(sAR);
        }

        // GET: ExternalSAR/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAR sAR = await db.SarActivities.FindAsync(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }
            return View(sAR);
        }

        // POST: ExternalSAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SAR sAR = await db.SarActivities.FindAsync(id);
            db.SarActivities.Remove(sAR);
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
