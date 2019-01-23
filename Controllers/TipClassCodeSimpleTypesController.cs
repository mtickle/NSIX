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
    public class TipClassCodeSimpleTypesController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: TipClassCodeSimpleTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.TipClassCodeSimpleType.ToListAsync());
        }

        // GET: TipClassCodeSimpleTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipClassCodeSimpleType tipClassCodeSimpleType = await db.TipClassCodeSimpleType.FindAsync(id);
            if (tipClassCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(tipClassCodeSimpleType);
        }

        // GET: TipClassCodeSimpleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipClassCodeSimpleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TipClassCodeSimpleTypeID,FacetValue,Description")] TipClassCodeSimpleType tipClassCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.TipClassCodeSimpleType.Add(tipClassCodeSimpleType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipClassCodeSimpleType);
        }

        // GET: TipClassCodeSimpleTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipClassCodeSimpleType tipClassCodeSimpleType = await db.TipClassCodeSimpleType.FindAsync(id);
            if (tipClassCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(tipClassCodeSimpleType);
        }

        // POST: TipClassCodeSimpleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TipClassCodeSimpleTypeID,FacetValue,Description")] TipClassCodeSimpleType tipClassCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipClassCodeSimpleType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipClassCodeSimpleType);
        }

        // GET: TipClassCodeSimpleTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipClassCodeSimpleType tipClassCodeSimpleType = await db.TipClassCodeSimpleType.FindAsync(id);
            if (tipClassCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(tipClassCodeSimpleType);
        }

        // POST: TipClassCodeSimpleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipClassCodeSimpleType tipClassCodeSimpleType = await db.TipClassCodeSimpleType.FindAsync(id);
            db.TipClassCodeSimpleType.Remove(tipClassCodeSimpleType);
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
