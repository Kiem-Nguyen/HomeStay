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
                        ViewBag.Success = true;
                        return View("Login", objUser);
                    }
                }
            }
            ViewBag.Success = false;
            return RedirectToAction("UserDashBoard");
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