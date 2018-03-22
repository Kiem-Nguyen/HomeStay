using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Fillter;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class FormsController : Controller
    {
        [Protect]
        public ActionResult BasicForm()
        {
            return View();
        }

        [Protect]
        public ActionResult Validation()
        {
            return View();
        }

        [Protect]
        public ActionResult Wizard()
        {
            return View();
        }
    }
}