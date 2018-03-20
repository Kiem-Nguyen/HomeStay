using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Fillter;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class AdminController : Controller
    {
        [Protect]
        // GET: AdminControl/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAjax(Account objUser)
        {
            if (ModelState.IsValid)
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName.Equals(objUser.UseName) && a.PassWord.Equals(objUser.PassWord) && a.TypeUser == 0);
                    if (obj != null)
                    {
                        Session["UserAdmin"] = obj as Account;
                        return View("Admin", obj);
                    }
                }
            }
            return Json(new { success = false });
        }
    }
}