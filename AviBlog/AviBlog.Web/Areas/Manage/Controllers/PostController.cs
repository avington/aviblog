using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            PostListViewModel viewModel = _postService.GetAllPostForBlog();
            return View(viewModel);
        }

        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            string errormessage = _postService.FlagPostAsDeleted(id);
            if (! string.IsNullOrEmpty(errormessage))
            {
                PostListViewModel viewModel = _postService.GetAllPostForBlog();
                ViewData.Clear();
                viewModel.ErrorMessage = errormessage;
                return View("Index", viewModel);
            }
            return RedirectToActionPermanent("Index");
        }

        [AdminAuthorize]
        public ActionResult Create()
        {
            PostViewModel post = _postService.GetNewPostViewModel();
            return View(post);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Create(PostViewModel post)
        {
            string errorMessage = _postService.AddPost(post);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            ModelState.AddModelError("error",errorMessage);
            PostViewModel vm = _postService.GetNewPostViewModel();
            vm.ErrorMessage = errorMessage;
            return View(vm);
        }

        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            PostViewModel post = _postService.GetPostViewModelById(id);
            return View(post);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Edit(PostViewModel post)
        {
            string errorMessage = _postService.EditPost(post);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            ModelState.AddModelError("error", errorMessage);
            PostViewModel vm = _postService.GetNewPostViewModel();
            vm.ErrorMessage = errorMessage;
            return View(vm);
        }
    }
}