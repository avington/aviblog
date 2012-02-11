using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class BlogSiteController : Controller
    {
        private readonly IBlogSiteService _blogSiteService;

        public BlogSiteController(IBlogSiteService blogSiteService)
        {
            _blogSiteService = blogSiteService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            IList<BlogSiteViewModel> list = _blogSiteService.GetBlogsAll();
            return View(list);
        }


        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            BlogSiteViewModel view = _blogSiteService.GetBlogById(id);
            return View(view);
        }

        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            string errorMessage = _blogSiteService.DeleteBlog(id);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            IList<BlogSiteViewModel> list = _blogSiteService.GetBlogsAll();
            ViewBag.ErrorMessage = errorMessage;
            return View("Index");
        }

        [AdminAuthorize]
        public ActionResult Create()
        {
            var viewModel = new BlogSiteViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Create(BlogSiteViewModel view)
        {
            string errorMessage = _blogSiteService.AddBlog(view);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            view.ErrorMessage = errorMessage;
            return View(view);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Edit(BlogSiteViewModel view)
        {
            string errorMessage = _blogSiteService.SaveBlog(view);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            view.ErrorMessage = errorMessage;
            return View(view);
        }
    }
}