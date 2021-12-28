using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PA_MDM_MvcApp_2021.Areas.ManagementPanel.Helpers;
using PA_MDM_MvcApp_2021.Models;
using PagedList;

namespace PA_MDM_MvcApp_2021.Areas.ManagementPanel.Controllers
{
    [Auth]
    public class MdmBlogsController : Controller
    {
        private MDMContext db = new MDMContext();
       
        // GET: ManagementPanel/MdmBlogs
        public ActionResult Index(int? pagedList)
        {
            var mdmBlogs = db.MdmBlogs.Include(m => m.MdmBlogDetails);
         
            if (pagedList==null||pagedList==1)
            {
            return View(mdmBlogs.ToList().ToPagedList(1,10));
            }
            else
            {
                return View(mdmBlogs.ToList().ToPagedList(pagedList.Value, 10));
            }
        }

        // GET: ManagementPanel/MdmBlogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdmBlogs mdmBlogs = db.MdmBlogs.Find(id);
            if (mdmBlogs == null)
            {
                return HttpNotFound();
            }
            return View(mdmBlogs);
        }

        // GET: ManagementPanel/MdmBlogs/Create
        public ActionResult Create()
        {
            ViewBag.MdmId = new SelectList(db.MdmBlogDetails, "MdmId", "Description");
            ViewBag.CategoryId = new SelectList(db.MdmCategories, "CategoryId", "CategoryName");
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "NameSurname");
            ViewBag.TagId = db.Tags.ToList();
            return View();
        }

        // POST: ManagementPanel/MdmBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MdmId,Title,SubTitle,ImageURL,CategoryId,IsActive,RegisterDate,MdmBlogDetails,MdmCategories,Authors")] MdmBlogs mdmBlogs,HttpPostedFileBase imgFile /*,List<int>TagId*/,int AuthorId)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    mdmBlogs.ImageURL = ImageUpload.SaveImage(imgFile, 350, 200);
                }
              
                    mdmBlogs.Tags.Add(db.Tags.Find(1));
           
                mdmBlogs.RegisterDate = DateTime.Now;
                mdmBlogs.MdmBlogDetails.AuthorId = AuthorId;
                db.MdmBlogs.Add(mdmBlogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MdmId = new SelectList(db.MdmBlogDetails, "MdmId", "Description", mdmBlogs.MdmId);
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "NameSurname");
            ViewBag.TagId = db.Tags.ToList();
            return View(mdmBlogs);
        }

        // GET: ManagementPanel/MdmBlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdmBlogs mdmBlogs = db.MdmBlogs.Find(id);
            if (mdmBlogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.MdmId = new SelectList(db.MdmBlogDetails, "MdmId", "Description", mdmBlogs.MdmId);
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagName");
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "NameSurname",mdmBlogs.MdmBlogDetails.AuthorId);
            ViewBag.CategoryId = new SelectList(db.MdmCategories, "CategoryId", "CategoryName");
            return View(mdmBlogs);
        }

        // POST: ManagementPanel/MdmBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
          [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MdmId,Title,SubTitle,ImageURL,CategoryId,IsActive,RegisterDate,MdmBlogDetails,MdmCategories,Authors")] MdmBlogs mdmBlogs,HttpPostedFileBase imgFile/*,List<int>TagId*/, int AuthorId )
        {
            if (ModelState.IsValid)
            {
                MdmBlogs update = db.MdmBlogs.Find(mdmBlogs.MdmId);
                if (imgFile!=null)
                {
                    ImageUpload.DeleteByPath(update.ImageURL);
                    update.ImageURL = ImageUpload.SaveImage(imgFile, 350, 200);
             
                }
                    mdmBlogs.Tags.Clear();
                        update.Tags.Add(db.Tags.Find(1));
    
              
                update.RegisterDate = DateTime.Now;
                update.IsActive = mdmBlogs.IsActive;
                update.SubTitle = mdmBlogs.SubTitle;
                update.Title = mdmBlogs.Title;
                update.CategoryId = mdmBlogs.CategoryId;
                //update.CategoryId = mdmBlogs.CategoryId;
                update.MdmBlogDetails.AuthorId = AuthorId;
                update.MdmBlogDetails.Description = mdmBlogs.MdmBlogDetails.Description;
                update.MdmBlogDetails.VideoURL = mdmBlogs.MdmBlogDetails.VideoURL;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MdmId = new SelectList(db.MdmBlogDetails, "MdmId", "Description", mdmBlogs.MdmId);
            return View(mdmBlogs);
        }

        // GET: ManagementPanel/MdmBlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MdmBlogs mdmBlogs = db.MdmBlogs.Find(id);
            if (mdmBlogs == null)
            {
                return HttpNotFound();
            }
            return View(mdmBlogs);
        }

        // POST: ManagementPanel/MdmBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MdmBlogs mdmBlogs = db.MdmBlogs.Find(id);
            MdmBlogDetails details = db.MdmBlogDetails.Find(id);
            ImageUpload.DeleteByPath(mdmBlogs.ImageURL);
            mdmBlogs.Tags.Clear();
            foreach (var item in mdmBlogs.MdmComments.ToList())
            {
                db.MdmComments.Remove(item);
            }

            db.MdmBlogDetails.Remove(details);
            db.MdmBlogs.Remove(mdmBlogs);
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
