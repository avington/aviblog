using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IBlogSiteService _blogSiteService;

        public LayoutController(IBlogSiteService blogSiteService)
        {
            _blogSiteService = blogSiteService;
        }

        public ActionResult PrimarySiteHtml(string id)
        {
            BlogSiteViewModel blog = _blogSiteService.GetFirstPrimarySiteBlog();
            if (blog == null) return new EmptyResult();

            IList<HtmlFragmentViewModel> list = blog.HtmlFragments.Where(x => x.SelectedLocationName == id).ToList();
            return PartialView("_HtmlFragment",list);
        }
    }
}