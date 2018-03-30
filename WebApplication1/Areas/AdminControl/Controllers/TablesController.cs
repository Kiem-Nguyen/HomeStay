using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Services;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class TablesController : Controller
    {
        private readonly IAdminServices _iadminservices;
        public TablesController(IAdminServices iadminservices)
        {
            this._iadminservices = iadminservices;
        }
        
        //[Protect]
        public ActionResult ImageHomestay()
        {
            var table = _iadminservices.GetAllTable();

            return View(table);
        }

        //[Protect]
        public ActionResult Homestay()
        {
            var table = _iadminservices.GetAllTable();

            return View(table);
        }

        //[Protect]
        public ActionResult Account()
        {
            var table = _iadminservices.GetAllTable();

            return View(table);
        }

        [HttpPost]
        public ActionResult GetAllHomeStay()
        {
            var data = _iadminservices.GetAllHomeStay();

            return Json(new { data = data, success = true });
        }

        [HttpPost]
        public ActionResult RemoveImage(int id, string src)
        {
            var data = _iadminservices.DeleteImage(id, src);
            return Json(new { data = data });
        }

        //[HttpPost]
        //public ActionResult EditImage(ImageHomeStay id)
        //{
        //    var data = _iadminservices.EditImage(id);
        //    return Json(new { data = data });
        //}

        [HttpPost]
        public ActionResult getImageByID(int id)
        {
            var data = _iadminservices.getItemImageHomeStay(id);
            if (data == null)
                return Json(new { data = false });
            return Json(new { data = data });
        }
    }
}