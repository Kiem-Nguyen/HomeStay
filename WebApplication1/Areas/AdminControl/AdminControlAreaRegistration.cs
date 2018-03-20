using System.Web.Mvc;

namespace WebApplication1.Areas.AdminControl
{
    public class AdminControlAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminControl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminControl_default",
                "AdminControl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}