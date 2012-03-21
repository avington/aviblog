using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult File(string postId, IEnumerable<HttpPostedFileBase> files)
        {
            _uploadService.Upload(files);
            if (postId.Equals("0")) return RedirectToAction("Create", "PostAdmin");
            return RedirectToActionPermanent("Edit", "PostAdmin", new {id = postId});
        }
    }
}