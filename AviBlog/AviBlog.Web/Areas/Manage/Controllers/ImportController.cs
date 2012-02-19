using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class ImportController : Controller
    {
        [AdminAuthorize]
         public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/blogml"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Successful");
        }

        public ActionResult Successful()
        {
            return View();
        }
    }
}