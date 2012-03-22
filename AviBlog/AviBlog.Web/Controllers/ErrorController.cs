using System.Net;
using System.Web;
using System.Web.Mvc;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound(string url)
        {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            var view = new NotFoundViewModel
                           {
                               RequestUrl = url,
                               ReferrerUrl = Request.UrlReferrer != null &&
                                             Request.UrlReferrer.OriginalString != url
                                                 ? Request.UrlReferrer.OriginalString
                                                 : null
                           };
            return View("NotFound", view);
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return View();
        }

 
    }
}