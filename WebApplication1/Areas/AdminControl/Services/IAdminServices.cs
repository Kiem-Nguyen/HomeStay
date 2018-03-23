using System.Collections.Generic;
using WebApplication1.Areas.AdminControl.Models;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Services
{
    public interface IAdminServices
    {
        Account GetAcount();

        List<WebApplication1.Models.HomeStay> GetAllHomeStay();

        FormViewModel GetAllTable();
    }
}
