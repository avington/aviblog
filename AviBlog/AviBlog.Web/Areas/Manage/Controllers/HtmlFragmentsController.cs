using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class HtmlFragmentsController : Controller
    {
        private readonly IBlogSiteService _blogSiteService;
        private readonly IHtmlFragmentService _htmlFragmentService;

        public HtmlFragmentsController(IBlogSiteService blogSiteService, IHtmlFragmentService htmlFragmentService)
        {
            _blogSiteService = blogSiteService;
            _htmlFragmentService = htmlFragmentService;
        }

        [AdminAuthorize]
        public ActionResult Create(int blogId)
        {
            HtmlFragmentViewModel viewModel = _htmlFragmentService.GetViewModel(blogId);
            return View(viewModel);
        }

        [AdminAuthorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(HtmlFragmentViewModel viewModel)
        {
            string errorMessage = _htmlFragmentService.AddHtmlFragement(viewModel);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index", new {Id = viewModel.BlogId});
            viewModel.ErrorMessage = errorMessage;
            return View(viewModel);
        }

        [AdminAuthorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(HtmlFragmentViewModel viewModel)
        {
            string errorMessage = _htmlFragmentService.UpdateHtmlFragment(viewModel);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index", new {Id = viewModel.BlogId});
            viewModel.ErrorMessage = errorMessage;
            return View(viewModel);
        }

        [AdminAuthorize]
        public ActionResult Edit(int id, int blogId)
        {
            HtmlFragmentViewModel viewModel = _htmlFragmentService.GetHtmlFragment(id);
            viewModel.BlogId = blogId;
            return View(viewModel);
        }

        [AdminAuthorize]
        public ActionResult Index(int id)
        {
            BlogSiteViewModel view = _blogSiteService.GetBlogById(id);
            return View(view);
        }

        [AdminAuthorize]
        public ActionResult Delete(int id, int blogId)
        {
            string errorMessage = _htmlFragmentService.DeleteById(id);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index", new {Id = blogId});
            BlogSiteViewModel viewModel = _blogSiteService.GetBlogById(blogId);
            viewModel.ErrorMessage = errorMessage;
            return View("index", viewModel);
        }
    }
}