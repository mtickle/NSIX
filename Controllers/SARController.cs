using hbehr.recaptcha;
using Microsoft.AspNet.Identity;
using NSIX.DAL;
using NSIX.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace NSIX.Controllers
{
    public class SARController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: SAR --- Show me a list of SARs
        public async Task<ActionResult> Index()
        {

            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
                        
            //--- --------------------------------------------------------------------------
            //--- This section works by bringing back the SARs based on the 
            //--- SarActivities model and will not support including a list of 
            //--- vehicles attached to the SAR.
            //--- --------------------------------------------------------------------------
            var sarActivities = db.SarActivities
                .Include(s => s.TargetSectorCodeSimpleType)
                .Include(s => s.TipDomainCodeSimpleType)
                .Include(s => s.State)
                .Include(s => s.SuspiciousActivityCodeSimpleType)
                .Include(s => s.TipClassCodeSimpleType);

            return View(await sarActivities.ToListAsync());
            //--- --------------------------------------------------------------------------

        }

        // GET: SAR/Details/5 --- Show me the detais for the selected SAR
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //--- Use this to make sure we have a valid SARID to display
            SAR sAR = await db.SarActivities.FindAsync(id);
            if (sAR == null)
            {
                return HttpNotFound();
            }

            //--- Create our new merged model
            var viewModel = new SarIndexData();

            //--- Add the selected SAR to the model
            viewModel.SARs = sAR;

            //--- Add all associated vehicles to the model.
            viewModel.SarVehicles = db.SarVehicles.Where(t => t.SarID.Equals(id.Value));
            
            //--- Return the view loaded with the viewModel
            return View(viewModel);
            
        }

        // GET: SAR/Create -- This shows the view for adding a SAR
        public ActionResult Create()
        {
            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "Description");
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "Description");
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name");
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "Description");
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "Description");
            return View();
        }

        // POST: SAR/Create -- This handles the creation of a SAR from form input
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ActivityDate,ActivityTime,Location,Address,City,StateAbbrev,ZipCode,Description,SuspiciousActivityCodeSimpleTypeID,TargetSectorCodeSimpleTypeID,TipClassCodeSimpleTypeID,TipDomainCodeSimpleTypeID")] SAR sAR)
        {

            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);

            if (validCaptcha)
            {

                if (ModelState.IsValid)
                {

                    sAR.CreatedByID = User.Identity.GetUserId();
                    sAR.CreatedByName = User.Identity.GetUserName();
                    sAR.CreatedDate = DateTime.Now;

                    sAR.FullAddress = sAR.Address + ", " + sAR.City + ", " + sAR.StateAbbrev + " " + sAR.ZipCode;

                    db.SarActivities.Add(sAR);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "Description", sAR.TargetSectorCodeSimpleTypeID);
                ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "Description", sAR.TipDomainCodeSimpleTypeID);
                ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", sAR.StateAbbrev);
                ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "Description", sAR.SuspiciousActivityCodeSimpleTypeID);
                ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "Description", sAR.TipClassCodeSimpleTypeID);
                return View(sAR);
            } else
            {
                return RedirectToAction("YouAreARobot", "Index");
            }
        } 

        // GET: SAR/Edit/5 -- This shows the view for editing a SAR
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
            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "Description", sAR.TargetSectorCodeSimpleTypeID);
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "Description", sAR.TipDomainCodeSimpleTypeID);
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", sAR.StateAbbrev);
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "Description", sAR.SuspiciousActivityCodeSimpleTypeID);
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "Description", sAR.TipClassCodeSimpleTypeID);
            return View(sAR);
        }

        //--- Testing changesets
        // POST: SAR/Edit/5 --- This handles the editing of a SAR from form input.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SarID,ActivityDate,ActivityTime,Location,Address,City,StateAbbrev,ZipCode,Description,SuspiciousActivityCodeSimpleTypeID,TargetSectorCodeSimpleTypeID,TipClassCodeSimpleTypeID,TipDomainCodeSimpleTypeID")] SAR sAR)
        {
            if (ModelState.IsValid)
            {
                //--- This is quasi-auditing information. 
                sAR.UpdatedByID = User.Identity.GetUserId();
                sAR.UpdatedByName = User.Identity.GetUserName();
                sAR.UpdatedDate = DateTime.Now;
                sAR.FullAddress = sAR.Address + ", " + sAR.City + ", " + sAR.StateAbbrev + " " + sAR.ZipCode;
                db.Entry(sAR).State = EntityState.Modified;

                //--- Don't update these. Setting IsModified to false tricks the controller from updating.
                db.Entry(sAR).Property(x => x.CreatedByID).IsModified = false;
                db.Entry(sAR).Property(x => x.CreatedByName).IsModified = false;
                db.Entry(sAR).Property(x => x.CreatedDate).IsModified = false;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TargetSectorCodeSimpleTypeID = new SelectList(db.TargetSectorCodeSimpleType, "TargetSectorCodeSimpleTypeID", "Description", sAR.TargetSectorCodeSimpleTypeID);
            ViewBag.TipDomainCodeSimpleTypeID = new SelectList(db.TipDomainCodeSimpleType, "TipDomainCodeSimpleTypeID", "Description", sAR.TipDomainCodeSimpleTypeID);
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", sAR.StateAbbrev);
            ViewBag.SuspiciousActivityCodeSimpleTypeID = new SelectList(db.SuspiciousActivityCodeSimpleType, "SuspiciousActivityCodeSimpleTypeID", "Description", sAR.SuspiciousActivityCodeSimpleTypeID);
            ViewBag.TipClassCodeSimpleTypeID = new SelectList(db.TipClassCodeSimpleType, "TipClassCodeSimpleTypeID", "Description", sAR.TipClassCodeSimpleTypeID);
            return View(sAR);
        }

        // GET: SAR/Delete/5 --- This shows the delete form.
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

        // POST: SAR/Delete/5 --- And this fires off the delete.
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
