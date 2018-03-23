using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Areas.AdminControl.Models;
using WebApplication1.Areas.AdminControl.Repository;
using WebApplication1.Models;

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

    }
}