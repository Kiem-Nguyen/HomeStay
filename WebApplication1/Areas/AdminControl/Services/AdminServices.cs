using System.Collections.Generic;
using WebApplication1.Areas.AdminControl.Models;
using WebApplication1.Models;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Web.Hosting;

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
            data.ImageForm = (dbContext.ImageHomeStays).OrderBy(x => x.IDHomeStay).ToList();
            return data;
        }

        public List<Chat> getChats()
        {
            var data = dbContext.Chats.Where(x => x.Seen == 0).ToList();
            return data;
        }

        public ImageHomeStay getItemImageHomeStay(int id)
        {
            var data = dbContext.ImageHomeStays.FirstOrDefault(x => x.IDImage == id);
            return data != null ? data : null;
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

                        string _FileName = Path.GetFileName(file.FileName);

                        if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + image.IDHomeStay)))
                            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + image.IDHomeStay));

                        string path1 = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + image.IDHomeStay);
                        string _path = Path.Combine(path1, _FileName);
                        file.SaveAs(_path);

                        image.Image = "UploadedFiles/" + image.IDHomeStay + "/" + _FileName;
                        db.ImageHomeStays.Add(image);
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

        public bool DeleteImage(int id, string path)
        {
            try
            {
                if (path == null || path.Length <= 0)
                    return false;
                path = "~/" + path;
                if (File.Exists(HostingEnvironment.MapPath(path)))
                    File.Delete(HostingEnvironment.MapPath(path));
                
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    var obj = db.ImageHomeStays.FirstOrDefault(x => x.IDImage.Equals(id));
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

        public bool EditImage(HttpPostedFileBase file, string idImage, string idHomeStay, string oldImage)
        {
            try
            {
                using (HomeStayVNEntities db = new HomeStayVNEntities())
                {
                    int id = int.Parse(idImage);
                    var obj = db.ImageHomeStays.FirstOrDefault(x => x.IDImage.Equals(id));
                    if (obj != null)
                    {
                        ImageHomeStay image = obj;

                        if(!string.IsNullOrWhiteSpace(oldImage))
                        {
                            string _FileName = Path.GetFileName(file.FileName);

                            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + idImage)))
                                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + idImage));

                            string path1 = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + idImage);
                            string _path = Path.Combine(path1, _FileName);
                            file.SaveAs(_path);

                            string path = "~/UploadedFiles/" + idImage + "/" + oldImage;
                            if (File.Exists(HostingEnvironment.MapPath(path)))
                                File.Delete(HostingEnvironment.MapPath(path));

                            image.Image = "UploadedFiles/" + idImage + "/" + _FileName;
                        }

                        image.IDHomeStay = int.Parse(idHomeStay);
                        db.ImageHomeStays.AddOrUpdate<ImageHomeStay>(obj);
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