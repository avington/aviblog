using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AviBlog.Web.Controllers;
using StructureMap;

namespace AviBlog.Web.App_Start
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null) return null;
                return ObjectFactory.GetInstance(controllerType) as IController;
            }
            catch (StructureMapException ex)
            {
                //if structuremap throws an error at this point I am going to assume that it is a 404 error
                    IController errorController = ObjectFactory.GetInstance<ErrorController>();
                    var errorRoute = new RouteData();
                    errorRoute.Values.Add("controller", "Error");
                    errorRoute.Values.Add("action", "Http404");
                    errorRoute.Values.Add("url", HttpContext.Current.Request.Url.OriginalString);
                    errorController.Execute(new RequestContext(requestContext.HttpContext, errorRoute));
                    return errorController;

            }

            
        }

    }
}