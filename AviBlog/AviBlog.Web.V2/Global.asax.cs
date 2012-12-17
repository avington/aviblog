namespace AviBlog.Web.V2
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AviBlog.Core.Services.Search;
    using AviBlog.Web.V2.App_Start;

    using StructureMap;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            IofC.InitializeStructureMap();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            BootstrapperBundler.Bundle();
            RouteManager.RegisterAllAreas();
            RouteManager.RegisterRoutes(RouteTable.Routes);
            BootstrapperMvc.RegisterGlobalFilters(GlobalFilters.Filters);
            BootstrapperAutoMapper.RegisterMappings();
            BootstrapperMvc.RegisterViewEngine();
        }

        protected void Application_End()
        {
            EndApplication();
        }

        public void EndApplication()
        {
            var searchEngine = ObjectFactory.GetInstance<ISearchEngineService>();
            if (searchEngine != null) searchEngine.Dispose();
        }
    }
}