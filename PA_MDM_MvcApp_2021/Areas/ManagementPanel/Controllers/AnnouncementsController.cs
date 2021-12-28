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
    public class AnnouncementsController : Controller
    {
   
        private MDMContext db = new MDMContext();

        // GET: ManagementPanel/Announcements
     
        public ActionResult Index()
        {
            return View(db.Announcements.ToList());
        }

        // GET: ManagementPanel/Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcements = db.Announcements.Find(id);
            if (announcements == null)
            {
                return HttpNotFound();
            }
            return View(announcements);
        }

        // GET: ManagementPanel/Announcements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnnouncementId,Title,Description,ImageURL,IsActvie,RegisterDate")] Announcements announcements,HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile!=null)
                {
                    announcements.ImageURL = ImageUpload.SaveImage(imgFile,400,600);
                }
                announcements.RegisterDate = DateTime.Now;
                db.Announcements.Add(announcements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcements);
        }

        // GET: ManagementPanel/Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcements = db.Announcements.Find(id);
            if (announcements == null)
            {
                return HttpNotFound();
            }
            return View(announcements);
        }

        // POST: ManagementPanel/Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnnouncementId,Title,Description,ImageURL,IsActvie,RegisterDate")] Announcements announcements, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                Announcements update = db.Announcements.Find(announcements.AnnouncementId);
                if (imgFile!=null)
                {
                    ImageUpload.DeleteByPath(update.ImageURL);
                    update.ImageURL = ImageUpload.SaveImage(imgFile, 400, 600);
                }
                update.Description = announcements.Description;
                update.IsActvie = announcements.IsActvie;
                update.RegisterDate = DateTime.Now;
                update.Title = announcements.Title;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcements);
        }

        // GET: ManagementPanel/Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcements = db.Announcements.Find(id);
            if (announcements == null)
            {
                return HttpNotFound();
            }
            return View(announcements);
        }

        // POST: ManagementPanel/Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcements announcements = db.Announcements.Find(id);
            db.Announcements.Remove(announcements);
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
