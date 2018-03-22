﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Fillter;
using WebApplication1.Areas.AdminControl.Models;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class AdminController : Controller
    {
        private readonly HomeStayVNEntities dbContext;
        public AdminController()
        {
            dbContext = new HomeStayVNEntities();
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
        public ActionResult Tables()
        {

            FormViewModel data = new FormViewModel();
            data.AboutForm = (dbContext.About_Us_Admins).ToList();
            data.AcountForm = (dbContext.Accounts).ToList();
            data.AdressForm = (dbContext.Adresses).ToList();
            data.EventForm = (dbContext.Events).ToList();
            data.HomestayForm = (dbContext.HomeStays).ToList();
            data.ImageForm = (dbContext.ImageHomeStays).ToList();

            return View(data);
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