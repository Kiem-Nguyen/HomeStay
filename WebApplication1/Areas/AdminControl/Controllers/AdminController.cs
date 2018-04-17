using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Fillter;
using WebApplication1.Areas.AdminControl.Models;
using WebApplication1.Areas.AdminControl.Services;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminServices _iadminservices;
        public AdminController(IAdminServices iadminservices)
        {
            this._iadminservices = iadminservices;
        }

        [Protect]
        public ActionResult Index()
        {
            return View();
        }
        
        [Protect]
        public ActionResult ChartsAndGraphs()
        {
            return View();
        }

        [Protect]
        public ActionResult Widgets()
        {
            return View();
        }

        [Protect]
        public ActionResult ButtonsIcons()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Messagers()
        {
            var data = _iadminservices.getChats();
            return Json(new { data = data, count = data.Count() });
        }

        [HttpPost]
        public ActionResult LoginAdmin(Account objUser)
        {
            Session.Remove("UserAdmin");
            if (ModelState.IsValid)
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName== objUser.UseName && a.PassWord == objUser.PassWord);
                    if (obj != null && (obj.TypeUser == 0 || obj.TypeUser == 2))
                    {
                        Session["UserAdmin"] = obj as Account;
                        return Json(new { success = true });
                    }
                }
            }
            return Json(new { success = false });
        }
    }
}