using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class ImportController : Controller
    {
        private readonly IBlogMLService _blogMLService;
        private readonly IBlogSiteService _blogSiteService;
        private readonly IProfileUserService _profileUserService;

        public ImportController(IBlogMLService blogMLService, IBlogSiteService blogSiteService,
                                IProfileUserService profileUserService)
        {
            _blogMLService = blogMLService;
            _blogSiteService = blogSiteService;
            _profileUserService = profileUserService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            ImportViewModel model = ImportViewModel();
            return View(model);
        }

        
        [HttpPost]
        [AdminAuthorize]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files, ImportViewModel model)
        {
            string errorMessage = _blogMLService.SaveAndImport(files.ToList(), model);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToAction("Successful");
            ImportViewModel modelReloaded = ImportViewModel();
            return View("Index",modelReloaded);
        }

        [AdminAuthorize]
        public ActionResult Successful()
        {
            return View();
        }

        [AdminAuthorize]
        private ImportViewModel ImportViewModel()
        {
            List<BlogSiteViewModel> blogs = _blogSiteService.GetBlogsAll()
                .Where(x => x.IsActive)
                .ToList();
            BlogSiteViewModel primary = _blogSiteService.GetBlogsAll()
                .FirstOrDefault(x => x.IsPrimary);
            SelectList selectList = primary == null
                                        ? new SelectList(blogs, "BlogId", "BlogName")
                                        : new SelectList(blogs, "BlogId", "BlogName", primary.BlogId);

            List<UserViewModel> users = _profileUserService.GetAllUsers()
                .Where(x => x.IsActive)
                .ToList();
            var uSelectList = new SelectList(users, "Id", "UserName");

            var model = new ImportViewModel
            {
                BlogSiteList = selectList,
                UserList = uSelectList
            };
            return model;
        }

    }
}