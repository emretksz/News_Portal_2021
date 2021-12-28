using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA_MDM_MvcApp_2021.Areas.ManagementPanel.Controllers
{
    public class AdminController : Controller
    {
        // GET: ManagementPanel/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}