using System;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Application;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class PostController : Controller
    {
        private readonly IHttpHelper _helper;
        private readonly IPostService _postService;

        public PostController(IHttpHelper helper, IPostService postService)
        {
            _helper = helper;
            _postService = postService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            var blogId = _helper.GetCookieValue("blog");
            PostListViewModel viewModel = _postService.GetPosts(blogId);
            return View(viewModel);

        }
    }
}