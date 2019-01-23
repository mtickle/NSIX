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
    public class TipDomainCodeSimpleTypesController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: TipDomainCodeSimpleTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.TipDomainCodeSimpleType.ToListAsync());
        }

        // GET: TipDomainCodeSimpleTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipDomainCodeSimpleType tipDomainCodeSimpleType = await db.TipDomainCodeSimpleType.FindAsync(id);
            if (tipDomainCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(tipDomainCodeSimpleType);
        }

        // GET: TipDomainCodeSimpleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipDomainCodeSimpleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TipDomainCodeSimpleTypeID,FacetValue,Description")] TipDomainCodeSimpleType tipDomainCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.TipDomainCodeSimpleType.Add(tipDomainCodeSimpleType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipDomainCodeSimpleType);
        }

        // GET: TipDomainCodeSimpleTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipDomainCodeSimpleType tipDomainCodeSimpleType = await db.TipDomainCodeSimpleType.FindAsync(id);
            if (tipDomainCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(tipDomainCodeSimpleType);
        }

        // POST: TipDomainCodeSimpleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TipDomainCodeSimpleTypeID,FacetValue,Description")] TipDomainCodeSimpleType tipDomainCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipDomainCodeSimpleType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipDomainCodeSimpleType);
        }

        // GET: TipDomainCodeSimpleTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipDomainCodeSimpleType tipDomainCodeSimpleType = await db.TipDomainCodeSimpleType.FindAsync(id);
            if (tipDomainCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(tipDomainCodeSimpleType);
        }

        // POST: TipDomainCodeSimpleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipDomainCodeSimpleType tipDomainCodeSimpleType = await db.TipDomainCodeSimpleType.FindAsync(id);
            db.TipDomainCodeSimpleType.Remove(tipDomainCodeSimpleType);
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
