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
    public class AuthorsController : Controller
    {
        private MDMContext db = new MDMContext();

        // GET: ManagementPanel/Authors,
      
        public ActionResult Index()
        {
            var authors = db.Authors.Include(a => a.AuthorCategories);
            return View(authors.ToList());
        }

        // GET: ManagementPanel/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            return View(authors);
        }

        // GET: ManagementPanel/Authors/Create
        public ActionResult Create()
        {
            ViewBag.AuthorCategoryId = new SelectList(db.AuthorCategories, "AuthorCategoryId", "AuthorCategoryName");
            return View();
        }

        // POST: ManagementPanel/Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorId,NameSurname,ImageURL,FacebookURL,YoutubeURL,TwitterURL,InstagramURL,IsActive,RegisterDate,AuthorCategoryId")] Authors authors,HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile!=null)
                {
                    authors.ImageURL = ImageUpload.SaveImage(imgFile, 120,100);
                }
                authors.RegisterDate = DateTime.Now;
                db.Authors.Add(authors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorCategoryId = new SelectList(db.AuthorCategories, "AuthorCategoryId", "AuthorCategoryName", authors.AuthorCategoryId);
            return View(authors);
        }

        // GET: ManagementPanel/Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorCategoryId = new SelectList(db.AuthorCategories, "AuthorCategoryId", "AuthorCategoryName", authors.AuthorCategoryId);
            return View(authors);
        }

        // POST: ManagementPanel/Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorId,NameSurname,ImageURL,FacebookURL,YoutubeURL,TwitterURL,InstagramURL,IsActive,RegisterDate,AuthorCategoryId")] Authors authors, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                Authors update = db.Authors.Find(authors.AuthorId);
                update.AuthorCategoryId = authors.AuthorCategoryId;
                if (imgFile!=null)
                {
                    ImageUpload.DeleteByPath(update.ImageURL);
                    update.ImageURL = ImageUpload.SaveImage(imgFile,120,100);
                }
                update.FacebookURL = authors.FacebookURL;
                update.InstagramURL = authors.InstagramURL;
                update.IsActive = authors.IsActive;
                update.NameSurname = authors.NameSurname;
                update.RegisterDate = DateTime.Now;
                update.TwitterURL = authors.TwitterURL;
                update.YoutubeURL = authors.YoutubeURL;

        
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorCategoryId = new SelectList(db.AuthorCategories, "AuthorCategoryId", "AuthorCategoryName", authors.AuthorCategoryId);
            return View(authors);
        }

        // GET: ManagementPanel/Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authors authors = db.Authors.Find(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            return View(authors);
        }

        // POST: ManagementPanel/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authors authors = db.Authors.Find(id);
            ImageUpload.DeleteByPath(authors.ImageURL);
            db.Authors.Remove(authors);
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
