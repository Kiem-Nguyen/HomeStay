using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.AdminControl.Services;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class UploadController : Controller
    {
        private readonly IAdminServices _iadminservices;
        public UploadController(IAdminServices iadminservices)
        {
            this._iadminservices = iadminservices;
        }

        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file, string listId)
        {
            try
            {
                var listID = listId.Split(',');
                if (file.ContentLength > 0)
                {
                    _iadminservices.AddImage(listID, file);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return Json(new { success = true , messeger = "File Uploaded Successfully!!" });
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return Json(new { success = false, messeger = "File upload failed!!" });
            }
        }
    }
}