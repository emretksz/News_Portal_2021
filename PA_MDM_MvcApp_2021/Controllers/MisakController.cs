using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA_MDM_MvcApp_2021.Controllers
{
    public class MisakController : Controller
    {
        // GET: Misak
        public ActionResult MisakIndex()
        {
            return View();
        }
        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult MisakBlogDetails()
        {
            return View();
        }

        public ActionResult LocationBlogs(int id)
        { 
        /// kategori blogunda lokasyon id göndereciğm ve burada o laksayondaki yazılar sıralanacak
            return View();
        }

       
    }
}