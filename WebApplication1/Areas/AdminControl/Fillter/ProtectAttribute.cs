using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Fillter
{
    public class ProtectAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var master = HttpContext.Current.Session["UserAdmin"] as Account;
            if (master == null)
            {
                HttpContext.Current.Session["Message"] = "Please login!";
                HttpContext.Current.Response.Redirect("/AdminControl/Admin/Login");
                return;
            }
        }
    }
}