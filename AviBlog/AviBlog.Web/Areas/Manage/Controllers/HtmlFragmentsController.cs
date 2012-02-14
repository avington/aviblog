using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Entities;
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


        [HttpPost]
        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index(int id)
        {
            BlogSiteViewModel view = _blogSiteService.GetBlogById(id);
            return View(view);
        }

        public ActionResult Delete(int id)
        {
            string errorMessage = _htmlFragmentService.DeleteById(id)
        }
    }
}