using System.Collections.Generic;
using WebApplication1.Areas.AdminControl.Models;
using WebApplication1.Models;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Linq;

namespace WebApplication1.Areas.AdminControl.Services
{
    public class AdminServices : IAdminServices
    {
        #region Fields and Properties

       // private readonly IAdminRepository _iAdminServicesy;
        private readonly HomeStayVNEntities dbContext;

        #endregion Fields and Properties

        #region Constructor

        public AdminServices()
        {
            dbContext = new HomeStayVNEntities();
        }

        #endregion Constructor

        public Account GetAcount()
        {
            return new Account()
            {

            };
        }

        public List<WebApplication1.Models.HomeStay> GetAllHomeStay()
        {
            List<WebApplication1.Models.HomeStay> data = new List<WebApplication1.Models.HomeStay>();
            data = (dbContext.HomeStays).ToList();
            return data;
        }

        public FormViewModel GetAllTable()
        {
            FormViewModel data = new FormViewModel();
            data.AboutForm = (dbContext.About_Us_Admins).ToList();
            data.AcountForm = (dbContext.Accounts).ToList();
            data.AdressForm = (dbContext.Adresses).ToList();
            data.EventForm = (dbContext.Events).ToList();
            data.HomestayForm = (dbContext.HomeStays).ToList();
            data.ImageForm = (dbContext.ImageHomeStays).ToList();
            return data;
        }

        public bool AddImage(string[] idHomestay, HttpPostedFileBase file)
        {
            try
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    foreach(var id in idHomestay)
                    {
                        ImageHomeStay image = new ImageHomeStay();
                        image.IDHomeStay = int.Parse(id);
                        db.ImageHomeStays.Add(image);
                        db.SaveChanges();

                        string _FileName = Path.GetFileName(file.FileName);

                        if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + image.IDImage)))
                            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + image.IDImage));

                        string path1 = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + image.IDImage);
                        string _path = Path.Combine(path1, _FileName);
                        file.SaveAs(_path);

                        image.Image = "UploadedFiles/" + image.IDImage + "/" + _FileName;
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteImage(int id)
        {
            try
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.ImageHomeStays.FirstOrDefault(a => a.IDHomeStay.Equals(id));
                    if (obj != null)
                    {
                        db.ImageHomeStays.Remove(obj);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}