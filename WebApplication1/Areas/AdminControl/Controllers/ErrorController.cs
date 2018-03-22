using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Fillter;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class ErrorController : Controller
    {
        [Protect]
        public ActionResult PageNotFound()
        {
            return View();
        }

        [Protect]
        public ActionResult ServerError()
        {
            return View();
        }
    }
}