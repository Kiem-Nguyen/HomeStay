using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Logout()
        {
            Session.Remove("User");
            return Json(new { success = true });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoginAccount(Account objUser)
        {
            if (ModelState.IsValid)
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName.Equals(objUser.UseName) && a.PassWord.Equals(objUser.PassWord));
                    if (obj != null)
                    {
                        Session["User"] = obj as Account;
                        return Json(new { success = true });
                    }
                }
            }
            return Json(new { success = false });
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}