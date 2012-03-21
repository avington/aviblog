using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace AviBlog.Core.ActionFilters
{
    public class AdminAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        #region IAuthorizationFilter Members

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("Inside OnAuthorization");
            if (filterContext.HttpContext.User.Identity.IsAuthenticated )
                return;

            HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
            
                
        }

        #endregion
    }
}