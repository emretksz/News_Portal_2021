using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PA_MDM_MvcApp_2021.Areas.ManagementPanel.Helpers;
using PA_MDM_MvcApp_2021.Models;

namespace PA_MDM_MvcApp_2021.Areas.ManagementPanel.Controllers
{
    [Auth]
    public class MisakLocationsController : Controller
    {
        private MDMContext db = new MDMContext();
      
        // GET: ManagementPanel/MisakLocations
        public ActionResult Index()
        {
            return View(db.MisakLocations.ToList());
        }

        // GET: ManagementPanel/MisakLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakLocations misakLocations = db.MisakLocations.Find(id);
            if (misakLocations == null)
            {
                return HttpNotFound();
            }
            return View(misakLocations);
        }

        // GET: ManagementPanel/MisakLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/MisakLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MisakLocationId,LocationName,IsActive,RegisterDate")] MisakLocations misakLocations)
        {
            if (ModelState.IsValid)
            {
                misakLocations.RegisterDate = DateTime.Now;
                db.MisakLocations.Add(misakLocations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(misakLocations);
        }

        // GET: ManagementPanel/MisakLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakLocations misakLocations = db.MisakLocations.Find(id);
            if (misakLocations == null)
            {
                return HttpNotFound();
            }
            return View(misakLocations);
        }

        // POST: ManagementPanel/MisakLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MisakLocationId,LocationName,IsActive,RegisterDate")] MisakLocations misakLocations)
        {
            if (ModelState.IsValid)
            {
                misakLocations.RegisterDate = DateTime.Now;
                db.Entry(misakLocations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(misakLocations);
        }

        // GET: ManagementPanel/MisakLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakLocations misakLocations = db.MisakLocations.Find(id);
            if (misakLocations == null)
            {
                return HttpNotFound();
            }
            return View(misakLocations);
        }

        // POST: ManagementPanel/MisakLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MisakLocations misakLocations = db.MisakLocations.Find(id);
            db.MisakLocations.Remove(misakLocations);
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
