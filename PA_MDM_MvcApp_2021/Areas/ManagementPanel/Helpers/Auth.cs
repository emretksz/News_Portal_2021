using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA_MDM_MvcApp_2021.Areas.ManagementPanel.Helpers
{


    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {


            if (HttpContext.Current.Session["KullaniciAdi"] == null)
            {

                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary()
            {
                     {"Action","Login" },
                     {"Controller","Account"}
            });



            }
        }
    }
}