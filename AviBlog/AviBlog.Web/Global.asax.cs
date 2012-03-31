using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using AviBlog.Core.Services;
using AviBlog.Web.App_Start;
using StructureMap;

namespace AviBlog.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            Bootstrapper.InitializeStructureMap();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            RouteManager.RegisterAllAreas();
            RouteManager.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.RegisterGlobalFilters(GlobalFilters.Filters);
            Bootstrapper.RegisterMappings();
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var identity = new GenericIdentity(authTicket.Name, "Forms");
            string[] roles = authTicket.UserData.Split(char.Parse("~"));
            var principal = new GenericPrincipal(identity, roles);
            Context.User = principal;
        }
    }
}