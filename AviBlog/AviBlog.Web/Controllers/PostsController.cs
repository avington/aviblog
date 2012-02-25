using System.Web.Mvc;
using AviBlog.Core.Services;

namespace AviBlog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }


        public ActionResult Post(string id)
        {
            var viewModel = _postService.GetPostBySlug(id);
            return View(viewModel);
        }
    }
}