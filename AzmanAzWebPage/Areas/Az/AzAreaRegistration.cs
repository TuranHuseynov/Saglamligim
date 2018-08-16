using System.Web.Mvc;

namespace AzmanAzWebPage.Areas.Az
{
    public class AzAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Az";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Az_default",
                "Az/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}