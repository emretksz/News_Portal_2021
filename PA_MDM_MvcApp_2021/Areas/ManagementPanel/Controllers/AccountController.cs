using PA_MDM_MvcApp_2021.Areas.ManagementPanel.Helpers;
using PA_MDM_MvcApp_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA_MDM_MvcApp_2021.Areas.ManagementPanel.Controllers
{
    public class AccountController : Controller
    {
        // GET: ManagementPanel/Account
        MDMContext db = new MDMContext();
        public ActionResult UserCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserCreate(string Email, string Name, string Password, HttpPostedFileBase imgFile)
        {
            Users user = new Users();

            if (String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Password))
            {
                return View("Alanların Hepsini Doldurun");
            }
            user.Email = Email;
            if (imgFile != null)
            {
                user.ImageURL = ImageUpload.SaveImage(imgFile, 120, 120);
            }

            foreach (var item in db.Roles)
            {
                if (item.RoleName == "User")
                {

                    user.Roles.Add(item);
                }
            }
            user.IsActive = true;
            var hash = Password.GetHashCode().ToString();
            user.Password = hash;
            user.RegisterDate = DateTime.Now;
            user.UserName = Name;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }



        // GET: Account
    
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(string Email, string Password)
        {
            var hash = Password.GetHashCode().ToString();
            var user = db.Users.FirstOrDefault(u => u.Email == Email && u.Password == hash);
            if (user == null)
            {
                return View();

            }
            else
            {
                bool a = false;

                foreach (var item in user.Roles)
                {
                    if (item.RoleName == "Admin")
                    {
                        Session["KullaniciAdi"] = user.UserName;
                        Session["KullaniciId"] = user.UserId;
               a = true;
                        //return RedirectToAction("Index", "MdmBlogs", new { area = "ManagementPanel" });
                    }
                    else
                    {
                        Session["KullaniciAdi"] = user.UserName;
                        Session["KullaniciId"] = user.UserId;
      
                        //return RedirectToAction("Index", "Home",new {area="" });
                    }
                }
                if (a==true)
                {
                    return RedirectToAction("Index", "Admin", new { area = "ManagementPanel" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
    

        }



        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
        }
    }
}