using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DetailController : Controller
    {
        private readonly HomeStayVNEntities dbContext;
        public DetailController()
        {
            dbContext = new HomeStayVNEntities();
        }
        // GET: Detail
        public ActionResult Product(int? id)
        {
            var detailHomeStay = dbContext.HomeStays;

            var data = detailHomeStay.ToList().FirstOrDefault(x => x.ID_HomeStay == id);

            return View(data);
        }
    }
}