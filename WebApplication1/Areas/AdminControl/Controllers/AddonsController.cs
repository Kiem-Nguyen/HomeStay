using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Areas.AdminControl.Fillter;
using WebApplication1.Areas.AdminControl.Models;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    [Protect]
    public class AddonsController : Controller
    {
        HomeStayVNEntities dbContact = new HomeStayVNEntities();
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult Chat()
        {
            var data = dbContact.Chats.ToList();
            ViewBag.Unread = data.Where(x => x.Seen == 0).ToList().Count();

            var results = data.GroupBy( p => p.Email, (key, g) => new ChatsViewModel { Email = key, item = g.ToList() }).ToList();
          
            return View(results);
        }
    }
}