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
    public class UsersController : Controller
    {
        private MDMContext db = new MDMContext();

        // GET: ManagementPanel/Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: ManagementPanel/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: ManagementPanel/Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = db.Roles.ToList();
            return View();
        }

        // POST: ManagementPanel/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Email,Password,IsActive,RegisterDate,ImageURL")] Users users,List<int>RoleId,HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile!=null)
                {
                    users.ImageURL = ImageUpload.SaveImage(imgFile, 250, 300);
                }

                foreach (var item in RoleId)
                {
                    users.Roles.Add(db.Roles.Find(item));
                }
                users.RegisterDate = DateTime.Now;
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: ManagementPanel/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(users);
        }

        // POST: ManagementPanel/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Email,Password,IsActive,RegisterDate,ImageURL")] Users users, List<int> RoleId, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                Users update = db.Users.Find(users.UserId);
                if (imgFile!=null)
                {
                    ImageUpload.DeleteByPath(update.ImageURL);

                    users.ImageURL = ImageUpload.SaveImage(imgFile, 250,300);
                }
                update.Roles.Clear();
                foreach (var item in RoleId)
                {
                    update.Roles.Add(db.Roles.Find(item));
                }
                update.RegisterDate = DateTime.Now;
                update.Password = users.Password;
                update.UserName = users.UserName;
                update.IsActive = users.IsActive;
                update.Email = users.Email;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: ManagementPanel/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: ManagementPanel/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);

            foreach (var item in db.Roles.ToList())
            {
                foreach (var item2 in users.Roles.ToList())
                {
                    if (item.RoleId==item2.RoleId)
                    {
                        users.Roles.Remove(item2);
                    }
                }
            }
            ImageUpload.DeleteByPath(users.ImageURL);

            db.Users.Remove(users);
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
