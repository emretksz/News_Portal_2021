using PA_MDM_MvcApp_2021.Models;
using PA_MDM_MvcApp_2021.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA_MDM_MvcApp_2021.Controllers
{   
   

    public class HomeController : Controller
    {
        MDMContext db = new MDMContext();
        public ActionResult Index()
        {

            var model = new IndexViewModel();
            model.MdmBlogs = db.MdmBlogs.Where(u => u.IsActive == true).ToList();
            model.MdmCategories = db.MdmCategories.Where(u => u.IsActive == true).ToList();
            model.MisakBlogs = db.MisakBlogs.Where(u => u.IsAcitive == true).ToList();
            model.Contacts = db.Contacts.Where(u => u.IsActive == true).ToList();
            // !!

            return View(model);
        }
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Abouts()
        {

            var model = new AboutViewModels();
            model.Contacts = db.Contacts.Where(u => u.IsActive == true).ToList();
            model.Abouts = db.Abouts.Where(u => u.IsActive == true).ToList();
            return View(model);
        }
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Contact()
        {
            var model = db.Contacts.Where(u => u.IsActive == true).ToList();
            return View(model);
        }
        public ActionResult Blogs(int?pageNumber, int?id, int? authorId)
        {
 
            var model = new BlogViewModels();

            if (id !=null)
            {

                if (pageNumber == null || pageNumber == 1)
                {
                    ViewBag.Page = 1;

                    model.MdmBlogs = db.MdmBlogs.Where(u => u.CategoryId == id).ToList().ToPagedList(1, 5);
                    ViewBag.PageCount = model.MdmBlogs.Count()+4;
                }

                else
                {
                    ViewBag.Page = pageNumber;
                    model.MdmBlogs = db.MdmBlogs.Where(u => u.CategoryId == id).ToList().ToPagedList(pageNumber.Value, 5);
                    ViewBag.PageCount = model.MdmBlogs.Count()+4;
                }
            }
            else if (pageNumber == null || pageNumber == 1)
            {
                ViewBag.Page = 1;
                model.MdmBlogs = db.MdmBlogs.Where(u => u.IsActive == true).ToList().ToPagedList(1, 5);
                ViewBag.PageCount = db.MdmBlogs.Where(u => u.IsActive == true).Count();
                model.Authors = db.Authors.Where(u => u.MdmBlogDetails.Any(c=>c.AuthorId== authorId)).ToList();
            }

            else
            {
                ViewBag.Page = pageNumber;
                model.MdmBlogs = db.MdmBlogs.Where(u => u.IsActive == true).ToList().ToPagedList(pageNumber.Value, 5);
                ViewBag.PageCount = db.MdmBlogs.Where(u=>u.IsActive==true).Count();
                model.Authors = db.Authors.Where(u => u.MdmBlogDetails.Any(c => c.AuthorId == authorId)).ToList();
            }


            //var sonuc = db.MdmBlogs.Where(u => u.IsActive == true).ToList();
            //ViewBag.PageCount = sonuc.Count();
            model.MdmCategories = db.MdmCategories.Where(u => u.IsActive == true).ToList();
      
            return View(model);

        }

        public ActionResult BlogDetails(int id, int? author)
        {

           
            if (author != null)
            {

            ViewBag.Yazar = author.Value;
            }
           


           
            ViewBag.Yazılar = db.Authors.ToList();
         
            var model = db.MdmBlogs.Find(id);
            return View(model);

        }

        public ActionResult CommentAdd(int MdmId, int? userId, string comment, string name, string email, int? IsReply)
        {
            MdmComments comments = new MdmComments();

            comments.MdmId = MdmId;
            if (IsReply != null)
            {
                comments.IsReply = IsReply.Value;
            }
            if (userId!=null)
            {
                Users users = db.Users.FirstOrDefault(u => u.UserId == userId);
                
                 comments.UserId = users.UserId;
                comments.GuestName = users.UserName;
                comments.GuestMail = users.Email;
                comments.Comment = comment;

            }
            else
            {
                comments.Comment = comment;
                comments.GuestName = name;
                comments.GuestMail = email;
            }
            
          
            db.MdmComments.Add(comments);
            db.SaveChanges();
            var model = db.MdmComments.Where(u => u.MdmId == MdmId).ToList();
            return PartialView("_CommentList", model);
        }

        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Authors()
        {
            var model = db.Authors.Where(a => a.IsActive == true).ToList();
            return View(model);
        }
        public ActionResult AuthorDetails(int id,int?pagedNumber)
        {
            if (pagedNumber==null||pagedNumber==1)
            {
                var model = db.MdmBlogs.Where(u => u.MdmBlogDetails.AuthorId == id).ToList().ToPagedList(1, 9);
                return View(model);
            }
            else
            {

            var model = db.MdmBlogs.Where(u => u.MdmBlogDetails.AuthorId == id).ToList().ToPagedList(pagedNumber.Value,9);
                return View(model);
            }

        }


    }
}