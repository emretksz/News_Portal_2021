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
    public class MisakBlogsController : Controller
    {
        private MDMContext db = new MDMContext();
        
        // GET: ManagementPanel/MisakBlogs
        public ActionResult Index()
        {
            var misakBlogs = db.MisakBlogs.Include(m => m.MisakBlogDetails).Include(m => m.MisakCategories).Include(m => m.MisakLocations).Include(m=>m.MisakBlogDetails.Authors);
            return View(misakBlogs.ToList());
        }

        // GET: ManagementPanel/MisakBlogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakBlogs misakBlogs = db.MisakBlogs.Find(id);
            if (misakBlogs == null)
            {
                return HttpNotFound();
            }
            return View(misakBlogs);
        }

        // GET: ManagementPanel/MisakBlogs/Create
        public ActionResult Create()
        {
            ViewBag.MisakBlogId = new SelectList(db.MisakBlogDetails, "MisakBlogId", "Description");
            ViewBag.MisakCategoryId = new SelectList(db.MisakCategories, "MisakCategoryId", "CategoryName");
            ViewBag.MisakLocationId = new SelectList(db.MisakLocations, "MisakLocationId", "LocationName");
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "NameSurname");
            ViewBag.TagId = db.MisakTags.ToList();
            return View();
        }

        // POST: ManagementPanel/MisakBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MisakBlogId,Tilte,SubTitle,VideoURL,ImageURL,MisakCategoryId,MisakLocationId,IsAcitive,RegisterDate,MisakBlogDetails,AuthorId")] MisakBlogs misakBlogs,HttpPostedFileBase imgFile,List<int>TagId)
        {
            if (ModelState.IsValid)
            {
                if (imgFile!=null)
                {
                    misakBlogs.ImageURL = ImageUpload.SaveImage(imgFile, 750, 375);
                }

                if (TagId!=null)
                {
                    foreach (var item in TagId)
                    {
                        misakBlogs.MisakTags.Add(db.MisakTags.Find(item));
                    }
                }
             

                misakBlogs.RegisterDate = DateTime.Now;
                db.MisakBlogs.Add(misakBlogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MisakBlogId = new SelectList(db.MisakBlogDetails, "MisakBlogId", "Description", misakBlogs.MisakBlogId);
            ViewBag.MisakCategoryId = new SelectList(db.MisakCategories, "MisakCategoryId", "CategoryName", misakBlogs.MisakCategoryId);
            ViewBag.MisakLocationId = new SelectList(db.MisakLocations, "MisakLocationId", "LocationName", misakBlogs.MisakLocationId);
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "NameSurname",misakBlogs.MisakBlogDetails.AuthorId);
            ViewBag.TagId = db.MisakTags.ToList();
            return View(misakBlogs);
        }

        // GET: ManagementPanel/MisakBlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakBlogs misakBlogs = db.MisakBlogs.Find(id);
            if (misakBlogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.MisakBlogId = new SelectList(db.MisakBlogDetails, "MisakBlogId", "Description", misakBlogs.MisakBlogId);
            ViewBag.MisakCategoryId = new SelectList(db.MisakCategories, "MisakCategoryId", "CategoryName", misakBlogs.MisakCategoryId);
            ViewBag.MisakLocationId = new SelectList(db.MisakLocations, "MisakLocationId", "LocationName", misakBlogs.MisakLocationId);
            ViewBag.TagId = new SelectList(db.MisakTags, "MisakTagId", "TagName");
            return View(misakBlogs);
        }

        // POST: ManagementPanel/MisakBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MisakBlogId,Tilte,SubTitle,ImageURL,MisakCategoryId,MisakLocationId,IsAcitive,RegisterDate,VideoURL,MisakBlogDetails,AuthorId")] MisakBlogs misakBlogs, HttpPostedFileBase imgFile, List<int> TagId)
        {
            if (ModelState.IsValid)
            {
                MisakBlogs update = db.MisakBlogs.Find(misakBlogs.MisakBlogId);

                if (imgFile != null)
                {
                    ImageUpload.DeleteByPath(update.ImageURL);
                    update.ImageURL = ImageUpload.SaveImage(imgFile, 750, 375);
                }
                update.MisakTags.Clear();
                if (TagId != null)
                {
                    foreach (var item in TagId)
                    {
                        update.MisakTags.Add(db.MisakTags.Find(item));
                    }
                }
                update.IsAcitive = misakBlogs.IsAcitive;
                update.MisakCategoryId = misakBlogs.MisakCategoryId;
                update.MisakLocationId = misakBlogs.MisakLocationId;
                update.RegisterDate = DateTime.Now;
                update.SubTitle = misakBlogs.SubTitle;
                update.Tilte = misakBlogs.Tilte;
                update.MisakBlogDetails.VideoURL = misakBlogs.MisakBlogDetails.VideoURL;
                update.MisakBlogDetails.Description = misakBlogs.MisakBlogDetails.Description;
                update.MisakBlogDetails.AuthorId = misakBlogs.MisakBlogDetails.AuthorId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                ViewBag.MisakBlogId = new SelectList(db.MisakBlogDetails, "MisakBlogId", "Description", misakBlogs.MisakBlogId);
                ViewBag.MisakCategoryId = new SelectList(db.MisakCategories, "MisakCategoryId", "CategoryName", misakBlogs.MisakCategoryId);
                ViewBag.MisakLocationId = new SelectList(db.MisakLocations, "MisakLocationId", "LocationName", misakBlogs.MisakLocationId);
                ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "NameSurname", misakBlogs.MisakBlogDetails.AuthorId);
                return View(misakBlogs);
        }

        // GET: ManagementPanel/MisakBlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisakBlogs misakBlogs = db.MisakBlogs.Find(id);
            if (misakBlogs == null)
            {
                return HttpNotFound();
            }
            return View(misakBlogs);
        }

        // POST: ManagementPanel/MisakBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MisakBlogs misakBlogs = db.MisakBlogs.Find(id);
            MisakBlogDetails details = db.MisakBlogDetails.Find(id);
            misakBlogs.MisakTags.Clear();
            ImageUpload.DeleteByPath(misakBlogs.ImageURL);

            foreach (var item in misakBlogs.MskComments.ToList())
            {
                db.MskComments.Remove(item);
            }

            db.MisakBlogDetails.Remove(details);
            db.MisakBlogs.Remove(misakBlogs);
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
