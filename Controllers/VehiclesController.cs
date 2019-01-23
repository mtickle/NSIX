using NSIX.DAL;
using NSIX.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NSIX.Controllers
{
    public class VehiclesController : Controller
    {
        private NSIXContext db = new NSIXContext();

        // GET: Vehicles
        public async Task<ActionResult> Index(int? id)
        {

            //--- Get a list of all vehicles in the database.
            var vehicle = db.Vehicle
                .Include(v => v.State)
                .Include(v => v.VehicleColor)
                .Include(v => v.VehicleMake)
                .Include(v => v.VehicleModel)
                .Include(v => v.SarVehicles);
            //.Include(v => v.SarVehicles.Where(t => t.VehicleID.Equals(v.VehicleID))); 

            //--- Create our new merged model
            var viewModel = new SuperIndexData
            {
                Vehicles = vehicle
            };

            //--- We're going to use the boolean values here to show different things 
            //--- in the Razor page, dependent on whether or not we're coming in from 
            //--- the SAR view.
            ViewBag.SarId = id;
            if (id == null)
            {
                ViewBag.ShowVehicleWarning = false;
                ViewBag.ShowBackToVehicles = true;
            }
            else
            {
                //--- Try to find a SAR with this ID
                SAR sar = db.SarActivities.Find(id);

                if (sar == null) //--- No SAR with that ID exists
                {
                    return HttpNotFound();
                }
                else //--- Found a SAR with the ID
                {
                    //--- These are used to toggle elements on the pages since it used
                    //--- both for adding a vehicle to a SAR and for just adding a vehicle
                    //--- without a SAR.
                    ViewBag.ShowVehicleWarning = true;
                    ViewBag.ShowBackToVehicles = false;
                }
            }

            return View(await vehicle.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Instructor instructor = db.Instructors.Include(i => i.FilePaths).SingleOrDefault(i => i.ID == id);

            //Vehicle vehicle = await db.Vehicle.FindAsync(id);
            Vehicle vehicle = db.Vehicle.Include(i => i.Files).SingleOrDefault(i => i.VehicleID == id);


            //--- Create our new merged model
            var viewModel = new VehicleIndexData
            {

                ////--- Add the selected Vehicle to the model
                Vehicle = vehicle,

                ////--- Add all associated SARs to the model.
                SarVehicles = db.SarVehicles.Where(t => t.VehicleID.Equals(id.Value))
            };

            ////--- Return the view loaded with the viewModel
            //return View(viewModel);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            //--- Check to see if there is a SarID coming in on the querystring. If
            //--- There is, we need to add it to the ViewBag so we can use it in the
            //--- Razor form.
            int SarID = 0;
            if (Request["SarID"] != null)
            {
                int.TryParse(Request["SarID"], out SarID);
                ViewBag.SarID = SarID;
            }

            //return View(vehicle);
            return View(viewModel);
        }

        // GET: Vehicles/Details/5
        public async Task<ActionResult> Images(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = await db.Vehicle.FindAsync(id);

            //--- Create our new merged model
            var viewModel = new VehicleIndexData
            {

                ////--- Add the selected Vehicle to the model
                Vehicle = vehicle,

                ////--- Add all associated SARs to the model.
                SarVehicles = db.SarVehicles.Where(t => t.VehicleID.Equals(id.Value))
            };

            ////--- Return the view loaded with the viewModel
            //return View(viewModel);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            //--- Check to see if there is a SarID coming in on the querystring. If
            //--- There is, we need to add it to the ViewBag so we can use it in the
            //--- Razor form.
            int SarID = 0;
            if (Request["SarID"] != null)
            {
                int.TryParse(Request["SarID"], out SarID);
                ViewBag.SarID = SarID;
            }

            //return View(vehicle);
            return View(viewModel);
        }

        // GET: Vehicles/Create
        public ActionResult Create(int? id)
        {
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name");
            ViewBag.VehicleColorID = new SelectList(db.VehicleColor, "VehicleColorID", "ColorName");
            ViewBag.VehicleMakeID = new SelectList(db.VehicleMake, "VehicleMakeID", "MakeName");
            ViewBag.VehicleModelID = new SelectList(db.VehicleModel, "VehicleModelID", "ModelName");

            //--- We're going to use the boolean values here to show different things 
            //--- in the Razor page, dependent on whether or not we're coming in from 
            //--- the SAR view.
            ViewBag.SarId = id;
            if (id == null)
            {
                ViewBag.ShowVehicleWarning = false;
                ViewBag.ShowBackToVehicles = true;
            } else
            {
                //--- Try to find a SAR with this ID
                SAR sar =  db.SarActivities.Find(id);

                if (sar == null) //--- No SAR with that ID exists
                {
                    return HttpNotFound();
                }
                else //--- Found a SAR with the ID
                {
                    //--- These are used to toggle elements on the pages since it used
                    //--- both for adding a vehicle to a SAR and for just adding a vehicle
                    //--- without a SAR.
                    ViewBag.ShowVehicleWarning = true;
                    ViewBag.ShowBackToVehicles = false;
                }
            }

            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VehicleID,LicencePlate,StateAbbrev,VehicleColorID,VehicleMakeID,VehicleModelID")] Vehicle vehicle, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    vehicle.Files = new List<File> { avatar };
                }

                db.Vehicle.Add(vehicle);
                await db.SaveChangesAsync();

                //--- Get the newly created VehicleID back from the object.
                int VehicleID = vehicle.VehicleID;

                //--- Now get the SAR ID from the hidden field in the form.
                int SarID = 0;
                if (Request["SarID"] != null)
                {
                    //--- Create a new SarVehicle object and add the vehicle ID and SAR ID
                    int.TryParse(Request["SarID"], out SarID);
                    SarVehicle sv = new SarVehicle
                    {
                        SarID = SarID,
                        VehicleID = VehicleID
                    };
                    db.SarVehicles.Add(sv);                  
                    await db.SaveChangesAsync();
                    //--- Go back to the SAR details page.
                    return RedirectToAction("Details","SAR", new { id = SarID });
                }
                    else
                {
                    //--- No SarID to pass in.
                    await db.SaveChangesAsync();
                    //--- Go back to the list of vehicles
                    return RedirectToAction("Index");
                }
            }

            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", vehicle.StateAbbrev);
            ViewBag.VehicleColorID = new SelectList(db.VehicleColor, "VehicleColorID", "ColorName", vehicle.VehicleColorID);
            ViewBag.VehicleMakeID = new SelectList(db.VehicleMake, "VehicleMakeID", "MakeName", vehicle.VehicleMakeID);
            ViewBag.VehicleModelID = new SelectList(db.VehicleModel, "VehicleModelID", "ModelName", vehicle.VehicleModelID);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            //--- Check to see if there is a SarID coming in on the querystring. If
            //--- There is, we need to add it to the ViewBag so we can use it in the
            //--- Razor form.
            int SarID = 0;
            if (Request["SarID"] != null)
            {
                int.TryParse(Request["SarID"], out SarID);
                ViewBag.SarID = SarID;
            }
            
                ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", vehicle.StateAbbrev);
                ViewBag.VehicleColorID = new SelectList(db.VehicleColor, "VehicleColorID", "ColorName", vehicle.VehicleColorID);
                ViewBag.VehicleMakeID = new SelectList(db.VehicleMake, "VehicleMakeID", "MakeName", vehicle.VehicleMakeID);
                ViewBag.VehicleModelID = new SelectList(db.VehicleModel, "VehicleModelID", "ModelName", vehicle.VehicleModelID);
                return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VehicleID,LicencePlate,StateAbbrev,VehicleColorID,VehicleMakeID,VehicleModelID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;

                //--- Now get the SAR ID from the hidden field in the form. 
                //--- If there is a SarID present, we need to redirect back to the 
                //--- SAR details view.
                int SarID = 0;
                if (Request["SarID"] != null)
                {
                    int.TryParse(Request["SarID"], out SarID);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Details", "SAR", new { id = SarID });
                }
                else
                {
                    //--- No SarID, just go back to the Index view.
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.StateAbbrev = new SelectList(db.State, "StateAbbrev", "Name", vehicle.StateAbbrev);
            ViewBag.VehicleColorID = new SelectList(db.VehicleColor, "VehicleColorID", "ColorName", vehicle.VehicleColorID);
            ViewBag.VehicleMakeID = new SelectList(db.VehicleMake, "VehicleMakeID", "MakeName", vehicle.VehicleMakeID);
            ViewBag.VehicleModelID = new SelectList(db.VehicleModel, "VehicleModelID", "ModelName", vehicle.VehicleModelID);
            return View(vehicle);
        }

        // REMOVE: Vehicles/Remove/5?SarID=2
        public async Task<ActionResult> Remove(int? id)
        {
            //--- This is very specific to removing vehicles from SARs so its 
            //--- a little loose with verification of things and whatnot

            int.TryParse(Request["SarID"], out int SarID);
            SarVehicle sarVehicle = await db.SarVehicles.FirstOrDefaultAsync(m => m.VehicleID == id);
            db.SarVehicles.Remove(sarVehicle);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "SAR", new { id = SarID });
         }

        // REMOVE: Vehicles/Attach/5?SarID=2
        public async Task<ActionResult> Attach(int id)
        {
            //--- This is very specific to adding existing vehicles to SARs so its 
            //--- a little loose with verification of things and whatnot

            int.TryParse(Request["SarID"], out int SarID);
            SarVehicle sv = new SarVehicle
            {
                SarID = SarID,
                VehicleID = id
            };
            db.SarVehicles.Add(sv);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "SAR", new { id = SarID });
        }

        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            db.Vehicle.Remove(vehicle);
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
