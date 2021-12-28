﻿using System;
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
    public class AuthorCategoriesController : Controller
    {
        private MDMContext db = new MDMContext();
    

        // GET: ManagementPanel/AuthorCategories
        public ActionResult Index()
        {
            return View(db.AuthorCategories.ToList());
        }

        // GET: ManagementPanel/AuthorCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorCategories authorCategories = db.AuthorCategories.Find(id);
            if (authorCategories == null)
            {
                return HttpNotFound();
            }
            return View(authorCategories);
        }

        // GET: ManagementPanel/AuthorCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/AuthorCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorCategoryId,AuthorCategoryName,IsActive,RegisterDate")] AuthorCategories authorCategories)
        {
            if (ModelState.IsValid)
            {
                authorCategories.RegisterDate = DateTime.Now;
                db.AuthorCategories.Add(authorCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorCategories);
        }

        // GET: ManagementPanel/AuthorCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorCategories authorCategories = db.AuthorCategories.Find(id);
            if (authorCategories == null)
            {
                return HttpNotFound();
            }
            return View(authorCategories);
        }

        // POST: ManagementPanel/AuthorCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorCategoryId,AuthorCategoryName,IsActive,RegisterDate")] AuthorCategories authorCategories)
        {
            if (ModelState.IsValid)
            {
                authorCategories.RegisterDate = DateTime.Now;
                db.Entry(authorCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorCategories);
        }

        // GET: ManagementPanel/AuthorCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorCategories authorCategories = db.AuthorCategories.Find(id);
            if (authorCategories == null)
            {
                return HttpNotFound();
            }
            return View(authorCategories);
        }

        // POST: ManagementPanel/AuthorCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorCategories authorCategories = db.AuthorCategories.Find(id);
            db.AuthorCategories.Remove(authorCategories);
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
