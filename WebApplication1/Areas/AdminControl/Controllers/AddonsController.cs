using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Fillter;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class AddonsController : Controller
    {
        [Protect]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Protect]
        public ActionResult Gallery()
        {
            return View();
        }

        [Protect]
        public ActionResult Calendar()
        {
            return View();
        }

        [Protect]
        public ActionResult Invoice()
        {
            return View();
        }

        [Protect]
        public ActionResult Chat()
        {
            return View();
        }
    }
}