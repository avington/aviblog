using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AviBlog.Core.Entities;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class HtmlFragmentsController : Controller
    {
        private readonly IBlogSiteService _blogSiteService;

        public HtmlFragmentsController(IBlogSiteService blogSiteService)
        {
            _blogSiteService = blogSiteService;
        }


        [HttpPost]
        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index(int id)
        {
            BlogSiteViewModel view = _blogSiteService.GetBlogById(id);
            return View(view.HtmlFragments);
        }
    }
}