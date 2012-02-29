using System.Web.Mvc;
using AviBlog.Core.Services;

namespace AviBlog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ISettingsService _settingsService;

        public PostsController(IPostService postService, ISettingsService settingsService)
        {
            _postService = postService;
            _settingsService = settingsService;
        }


        public ActionResult Post(string id)
        {
            var viewModel = _postService.GetPostBySlug(id);
            return View(viewModel);
        }

        public ActionResult PostSettings(string id)
        {
            var setting = _settingsService.GetSettingByKey(id);
            return PartialView("_PostSettings",setting);
        }
    }
}