using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult SignIn()
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
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName.Equals(objUser.UseName) && a.PassWord.Equals(objUser.PassWord) && a.TypeUser != 0);
                    if (obj != null)
                    {
                        Session["User"] = obj as Account;
                        return Json(new { success = true });
                    }
                }
            }
            return Json(new { success = false });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SignUpAccount(Account objUser)
        {
            if (ModelState.IsValid)
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName.Equals(objUser.UseName));
                    if (obj != null)
                    {
                        return Json(new { success = false });
                    }
                    else
                    {
                        Account signin = new Account();
                        signin.FirstName = objUser.FirstName;
                        signin.Lastname = objUser.Lastname;
                        signin.TypeUser = 1;
                        signin.UseName = objUser.UseName;
                        signin.PassWord = objUser.PassWord;

                        db.Accounts.Add(signin);

                        db.SaveChanges();

                        return Json(new { success = true });
                    }
                }
            }
            return Json(new { success = false });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(Account objUser)
        {
            if (ModelState.IsValid)
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.Accounts.FirstOrDefault(a => a.UseName.Equals(objUser.UseName) && a.EmailAddress.Equals(objUser.EmailAddress));
                    if (obj != null)
                    {
                        obj.PassWord = objUser.PassWord;
                        db.Accounts.Attach(obj);
                        db.Entry(obj).State = EntityState.Modified;

                        db.SaveChanges();

                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
            }
            return Json(new { success = false });
        }
    }
}