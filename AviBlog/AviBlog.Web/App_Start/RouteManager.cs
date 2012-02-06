using System.Web.Mvc;
using System.Web.Routing;

namespace AviBlog.Web.App_Start
{
    public class RouteManager
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        public static void RegisterAllAreas()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}