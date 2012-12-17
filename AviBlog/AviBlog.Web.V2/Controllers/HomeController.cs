namespace AviBlog.Web.V2.Controllers
{
    using System.Web.Mvc;

    using AviBlog.Core.ActionResults;
    using AviBlog.Core.Services;
    using AviBlog.Core.ViewModel;

    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        private readonly IProfileUserService _profileUserService;

        public HomeController(IPostService postService, IProfileUserService profileUserService)
        {
            _postService = postService;
            _profileUserService = profileUserService;
        }

        [OutputCache(Duration = 6000, VaryByParam = "*")]
        public ActionResult Index()
        {
            const int top = 5;
            PostListViewModel viewModel = _postService.GetTopMostRecentPosts(top);

            return View(viewModel);
        }

        [OutputCache(Duration = 6000, VaryByParam = "*")]
        public ActionResult About(int id)
        {
            UserViewModel user = _profileUserService.GetUserById(id);
            return View(user);
        }

        [OutputCache(Duration = 6000, VaryByParam = "*")]
        public RssResult Rss()
        {
            PostListViewModel postViewModel = _postService.GetAllPostForBlog();
            var posts = new RssResult(postViewModel);
            return posts;
        }
    }
}