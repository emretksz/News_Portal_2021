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
    public class MisakTagsController : Controller
    {
        private MDMContext db = new MDMContext();

        // GET: ManagementPanel/MisakTags
        public ActionResult Index()
        {
            return View(db.MisakTags.ToList());
        }

        // GET: ManagementPanel/MisakTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakTags misakTags = db.MisakTags.Find(id);
            if (misakTags == null)
            {
                return HttpNotFound();
            }
            return View(misakTags);
        }

        // GET: ManagementPanel/MisakTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/MisakTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MisakTagId,TagName,IsActive,RegisterDate")] MisakTags misakTags)
        {
            if (ModelState.IsValid)
            {
                misakTags.RegisterDate = DateTime.Now;
                db.MisakTags.Add(misakTags);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(misakTags);
        }

        // GET: ManagementPanel/MisakTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakTags misakTags = db.MisakTags.Find(id);
            if (misakTags == null)
            {
                return HttpNotFound();
            }
            return View(misakTags);
        }

        // POST: ManagementPanel/MisakTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MisakTagId,TagName,IsActive,RegisterDate")] MisakTags misakTags)
        {
            if (ModelState.IsValid)
            {
                misakTags.RegisterDate = DateTime.Now;
                db.Entry(misakTags).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(misakTags);
        }

        // GET: ManagementPanel/MisakTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakTags misakTags = db.MisakTags.Find(id);
            if (misakTags == null)
            {
                return HttpNotFound();
            }
            return View(misakTags);
        }

        // POST: ManagementPanel/MisakTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MisakTags misakTags = db.MisakTags.Find(id);
            db.MisakTags.Remove(misakTags);
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
