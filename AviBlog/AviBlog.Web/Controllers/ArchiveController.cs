using System;
using System.Linq;
using System.Web.Mvc;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Controllers
{
    public class ArchiveController : Controller
    {
        private readonly IPostService _postService;

        public ArchiveController(IPostService postService)
        {
            _postService = postService;
        }

        [OutputCache(Duration = 60000, VaryByParam = "*")]
        public ActionResult Index()
        {
            PostListViewModel viewModel = _postService.GetAllPostForBlog();
            viewModel.Posts = viewModel.Posts
                .Where(x => x.IsPublished && x.DatePublished.HasValue)
                .OrderByDescending(x => x.DatePublished.HasValue ? x.DatePublished.Value : new DateTime(1900, 1, 1))
                .ToList();

            return View(viewModel);
        }

        [OutputCache(Duration = 60000, VaryByParam = "*")]
        public ActionResult MostRecentPosts(int id)
        {
            if (id == 0) id = 5;
            PostListViewModel viewModel = _postService.GetAllPostForBlog();
            viewModel.Posts = viewModel.Posts
                .Where(x => x.IsPublished && x.DatePublished.HasValue)
                .OrderByDescending(x => x.DatePublished.HasValue ? x.DatePublished.Value : new DateTime(1900, 1, 1))
                .Take(id)
                .ToList();

            return PartialView("_RecentPosts", viewModel.Posts);
        }
    }
}