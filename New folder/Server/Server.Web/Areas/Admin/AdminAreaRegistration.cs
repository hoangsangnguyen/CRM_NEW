using System.Web.Mvc;

namespace Vino.Server.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Dashboard",action = "Index", id = UrlParameter.Optional },
                new[] { "Vino.Server.Web.Areas.Admin.Controllers" }
            );
        }
    }
}