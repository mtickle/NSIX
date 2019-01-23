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
    public class SuspiciousActivityCodeSimpleTypesController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: SuspiciousActivityCodeSimpleTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.SuspiciousActivityCodeSimpleType.ToListAsync());
        }

        // GET: SuspiciousActivityCodeSimpleTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspiciousActivityCodeSimpleType suspiciousActivityCodeSimpleType = await db.SuspiciousActivityCodeSimpleType.FindAsync(id);
            if (suspiciousActivityCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(suspiciousActivityCodeSimpleType);
        }

        // GET: SuspiciousActivityCodeSimpleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuspiciousActivityCodeSimpleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SuspiciousActivityCodeSimpleTypeID,FacetValue,Description")] SuspiciousActivityCodeSimpleType suspiciousActivityCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.SuspiciousActivityCodeSimpleType.Add(suspiciousActivityCodeSimpleType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(suspiciousActivityCodeSimpleType);
        }

        // GET: SuspiciousActivityCodeSimpleTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspiciousActivityCodeSimpleType suspiciousActivityCodeSimpleType = await db.SuspiciousActivityCodeSimpleType.FindAsync(id);
            if (suspiciousActivityCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(suspiciousActivityCodeSimpleType);
        }

        // POST: SuspiciousActivityCodeSimpleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SuspiciousActivityCodeSimpleTypeID,FacetValue,Description")] SuspiciousActivityCodeSimpleType suspiciousActivityCodeSimpleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspiciousActivityCodeSimpleType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(suspiciousActivityCodeSimpleType);
        }

        // GET: SuspiciousActivityCodeSimpleTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspiciousActivityCodeSimpleType suspiciousActivityCodeSimpleType = await db.SuspiciousActivityCodeSimpleType.FindAsync(id);
            if (suspiciousActivityCodeSimpleType == null)
            {
                return HttpNotFound();
            }
            return View(suspiciousActivityCodeSimpleType);
        }

        // POST: SuspiciousActivityCodeSimpleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SuspiciousActivityCodeSimpleType suspiciousActivityCodeSimpleType = await db.SuspiciousActivityCodeSimpleType.FindAsync(id);
            db.SuspiciousActivityCodeSimpleType.Remove(suspiciousActivityCodeSimpleType);
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
