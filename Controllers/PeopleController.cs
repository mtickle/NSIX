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
    public class PeopleController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: People
        public async Task<ActionResult> Index()
        {
            var person = db.Person.Include(p => p.Ethnicity).Include(p => p.EyeColor).Include(p => p.Gender).Include(p => p.HairColor).Include(p => p.Height).Include(p => p.Nationality).Include(p => p.Race).Include(p => p.SkinTone).Include(p => p.Weight);
            return View(await person.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.Person.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.EthnicityID = new SelectList(db.Ethnicity, "EthnicityID", "Description");
            ViewBag.EyeColorID = new SelectList(db.EyeColor, "EyeColorID", "Description");
            ViewBag.GenderID = new SelectList(db.Gender, "GenderID", "Description");
            ViewBag.HairColorID = new SelectList(db.HairColor, "HairColorID", "Description");
            ViewBag.HeightID = new SelectList(db.Height, "HeightID", "Description");
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Description");
            ViewBag.RaceID = new SelectList(db.Race, "RaceID", "Description");
            ViewBag.SkinToneID = new SelectList(db.SkinTone, "SkinToneID", "Description");
            ViewBag.WeightID = new SelectList(db.Weight, "WeightID", "Description");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,MiddleName,Suffix,LastName,Age,DateOfBirth,HeightID,WeightID,HairColorID,EyeColorID,GenderID,EthnicityID,RaceID,NationalityID,SkinToneID,Eyewear,FacialHair,PhysicalDescription,Alias,OtherInformation")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EthnicityID = new SelectList(db.Ethnicity, "EthnicityID", "EthnicityCode", person.EthnicityID);
            ViewBag.EyeColorID = new SelectList(db.EyeColor, "EyeColorID", "EyeColorCode", person.EyeColorID);
            ViewBag.GenderID = new SelectList(db.Gender, "GenderID", "GenderCode", person.GenderID);
            ViewBag.HairColorID = new SelectList(db.HairColor, "HairColorID", "HairColorCode", person.HairColorID);
            ViewBag.HeightID = new SelectList(db.Height, "HeightID", "Description", person.HeightID);
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Description", person.NationalityID);
            ViewBag.RaceID = new SelectList(db.Race, "RaceID", "RaceCode", person.RaceID);
            ViewBag.SkinToneID = new SelectList(db.SkinTone, "SkinToneID", "SkinToneCode", person.SkinToneID);
            ViewBag.WeightID = new SelectList(db.Weight, "WeightID", "Description", person.WeightID);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.Person.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.EthnicityID = new SelectList(db.Ethnicity, "EthnicityID", "EthnicityCode", person.EthnicityID);
            ViewBag.EyeColorID = new SelectList(db.EyeColor, "EyeColorID", "EyeColorCode", person.EyeColorID);
            ViewBag.GenderID = new SelectList(db.Gender, "GenderID", "GenderCode", person.GenderID);
            ViewBag.HairColorID = new SelectList(db.HairColor, "HairColorID", "HairColorCode", person.HairColorID);
            ViewBag.HeightID = new SelectList(db.Height, "HeightID", "Description", person.HeightID);
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Description", person.NationalityID);
            ViewBag.RaceID = new SelectList(db.Race, "RaceID", "RaceCode", person.RaceID);
            ViewBag.SkinToneID = new SelectList(db.SkinTone, "SkinToneID", "SkinToneCode", person.SkinToneID);
            ViewBag.WeightID = new SelectList(db.Weight, "WeightID", "Description", person.WeightID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,MiddleName,Suffix,LastName,Age,DateOfBirth,HeightID,WeightID,HairColorID,EyeColorID,GenderID,EthnicityID,RaceID,NationalityID,SkinToneID,Eyewear,FacialHair,PhysicalDescription,Alias,OtherInformation")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EthnicityID = new SelectList(db.Ethnicity, "EthnicityID", "EthnicityCode", person.EthnicityID);
            ViewBag.EyeColorID = new SelectList(db.EyeColor, "EyeColorID", "EyeColorCode", person.EyeColorID);
            ViewBag.GenderID = new SelectList(db.Gender, "GenderID", "GenderCode", person.GenderID);
            ViewBag.HairColorID = new SelectList(db.HairColor, "HairColorID", "HairColorCode", person.HairColorID);
            ViewBag.HeightID = new SelectList(db.Height, "HeightID", "Description", person.HeightID);
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Description", person.NationalityID);
            ViewBag.RaceID = new SelectList(db.Race, "RaceID", "RaceCode", person.RaceID);
            ViewBag.SkinToneID = new SelectList(db.SkinTone, "SkinToneID", "SkinToneCode", person.SkinToneID);
            ViewBag.WeightID = new SelectList(db.Weight, "WeightID", "Description", person.WeightID);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.Person.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Person person = await db.Person.FindAsync(id);
            db.Person.Remove(person);
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
