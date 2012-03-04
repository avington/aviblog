using System.Collections.Generic;
using System.Web.Mvc;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

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
            PostListViewModel viewModel = _postService.GetPostBySlug(id);
            if (viewModel.Posts == null)
               return new EmptyResult();
            return View(viewModel);
        }

        public ActionResult PostSettings(string id)
        {
            SettingViewModel setting = _settingsService.GetSettingByKey(id);
            return PartialView("_PostSettings", setting);
        }
    }
}