namespace AviBlog.Web.V2.App_Start
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using StructureMap;

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return null;
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}