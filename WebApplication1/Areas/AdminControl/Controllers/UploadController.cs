using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.AdminControl.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
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