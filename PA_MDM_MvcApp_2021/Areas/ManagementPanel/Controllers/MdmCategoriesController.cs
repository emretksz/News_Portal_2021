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
    public class MdmCategoriesController : Controller
    {
        private MDMContext db = new MDMContext();

        // GET: ManagementPanel/MdmCategories
    
        public ActionResult Index()
        {
            return View(db.MdmCategories.ToList());
        }

        // GET: ManagementPanel/MdmCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdmCategories mdmCategories = db.MdmCategories.Find(id);
            if (mdmCategories == null)
            {
                return HttpNotFound();
            }
            return View(mdmCategories);
        }

        // GET: ManagementPanel/MdmCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/MdmCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,IsActive,RegisterDate")] MdmCategories mdmCategories)
        {
            if (ModelState.IsValid)
            {
                mdmCategories.RegisterDate = DateTime.Now;
                db.MdmCategories.Add(mdmCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdmCategories);
        }

        // GET: ManagementPanel/MdmCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdmCategories mdmCategories = db.MdmCategories.Find(id);
            if (mdmCategories == null)
            {
                return HttpNotFound();
            }
            return View(mdmCategories);
        }

        // POST: ManagementPanel/MdmCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,IsActive,RegisterDate")] MdmCategories mdmCategories)
        {
            if (ModelState.IsValid)
            {
                mdmCategories.RegisterDate = DateTime.Now;
                db.Entry(mdmCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdmCategories);
        }

        // GET: ManagementPanel/MdmCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdmCategories mdmCategories = db.MdmCategories.Find(id);
            if (mdmCategories == null)
            {
                return HttpNotFound();
            }
            return View(mdmCategories);
        }

        // POST: ManagementPanel/MdmCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdmCategories mdmCategories = db.MdmCategories.Find(id);
            db.MdmCategories.Remove(mdmCategories);
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
