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

        //[Protect]
        public ActionResult Tables()
        {
            var data = _iadminservices.GetAllTable();

            return View(data);
        }

        [HttpPost]
        public ActionResult GetAllHomeStay()
        {
            var data = _iadminservices.GetAllHomeStay();

            return Json(new { data = data, success = true });
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
        public ActionResult LoginAdmin(Account objUser)
        {
            if (ModelState.IsValid)
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName.Equals(objUser.UseName) && a.PassWord.Equals(objUser.PassWord) && a.TypeUser == 0);
                    if (obj != null)
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