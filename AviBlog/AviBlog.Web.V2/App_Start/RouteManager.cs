namespace AviBlog.Web.V2.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Http;

    public class RouteManager
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("*.html|js|css|gif|jpg|jpeg|png|swf|ico");

            routes.MapRoute(
                "Error - 404",
                "NotFound",
                new {controller = "Error", action = "NotFound"}
                );

            routes.MapRoute(
                "Error - 500",
                "ServerError",
                new {controller = "Error", action = "ServerError"}
                );

            routes.MapRoute(
                "About",
                "Home/About",
                new { controller = "Home", action = "about", id = 1 });

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        public static void RegisterAllAreas()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}