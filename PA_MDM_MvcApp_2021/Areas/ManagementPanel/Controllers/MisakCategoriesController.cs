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
    public class MisakCategoriesController : Controller
    {
        private MDMContext db = new MDMContext();

        // GET: ManagementPanel/MisakCategories
     
        public ActionResult Index()
        {
            return View(db.MisakCategories.ToList());
        }

        // GET: ManagementPanel/MisakCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakCategories misakCategories = db.MisakCategories.Find(id);
            if (misakCategories == null)
            {
                return HttpNotFound();
            }
            return View(misakCategories);
        }

        // GET: ManagementPanel/MisakCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/MisakCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MisakCategoryId,CategoryName,IsActive,RegisterDate")] MisakCategories misakCategories)
        {
            if (ModelState.IsValid)
            {

                misakCategories.RegisterDate = DateTime.Now;
                db.MisakCategories.Add(misakCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(misakCategories);
        }

        // GET: ManagementPanel/MisakCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakCategories misakCategories = db.MisakCategories.Find(id);
            if (misakCategories == null)
            {
                return HttpNotFound();
            }
            return View(misakCategories);
        }

        // POST: ManagementPanel/MisakCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MisakCategoryId,CategoryName,IsActive,RegisterDate")] MisakCategories misakCategories)
        {
            if (ModelState.IsValid)
            {
                misakCategories.RegisterDate = DateTime.Now;
                db.Entry(misakCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(misakCategories);
        }

        // GET: ManagementPanel/MisakCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakCategories misakCategories = db.MisakCategories.Find(id);
            if (misakCategories == null)
            {
                return HttpNotFound();
            }
            return View(misakCategories);
        }

        // POST: ManagementPanel/MisakCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MisakCategories misakCategories = db.MisakCategories.Find(id);
            db.MisakCategories.Remove(misakCategories);
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
