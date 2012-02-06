using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace AviBlog.Web.App_Start
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return null;
            return ObjectFactory.GetInstance(controllerType) as IController;
        }

    }
}