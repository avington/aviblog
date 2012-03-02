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

        public ActionResult Index()
        {
            PostListViewModel viewModel = _postService.GetAllPostForBlog();
            return View(viewModel);
        }
    }
}