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
    public class TargetSectorCodeSimpleTypesController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: TargetSectorCodeSimpleTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.TargetSectorCodeSimpleType.ToListAsync());
        }

        // GET: TargetSectorCodeSimpleTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetSectorCodeSimpleType targetSectorCodeSimpleType = await db.TargetSectorCodeSimpleType.FindAsync(id);
            if (targetSectorCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(targetSectorCodeSimpleType);
        }

        // GET: TargetSectorCodeSimpleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TargetSectorCodeSimpleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TargetSectorCodeSimpleTypeID,FacetValue,Description")] TargetSectorCodeSimpleType targetSectorCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.TargetSectorCodeSimpleType.Add(targetSectorCodeSimpleType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(targetSectorCodeSimpleType);
        }

        // GET: TargetSectorCodeSimpleTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetSectorCodeSimpleType targetSectorCodeSimpleType = await db.TargetSectorCodeSimpleType.FindAsync(id);
            if (targetSectorCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(targetSectorCodeSimpleType);
        }

        // POST: TargetSectorCodeSimpleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TargetSectorCodeSimpleTypeID,FacetValue,Description")] TargetSectorCodeSimpleType targetSectorCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(targetSectorCodeSimpleType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(targetSectorCodeSimpleType);
        }

        // GET: TargetSectorCodeSimpleTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetSectorCodeSimpleType targetSectorCodeSimpleType = await db.TargetSectorCodeSimpleType.FindAsync(id);
            if (targetSectorCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(targetSectorCodeSimpleType);
        }

        // POST: TargetSectorCodeSimpleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TargetSectorCodeSimpleType targetSectorCodeSimpleType = await db.TargetSectorCodeSimpleType.FindAsync(id);
            db.TargetSectorCodeSimpleType.Remove(targetSectorCodeSimpleType);
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
