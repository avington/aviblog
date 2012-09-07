namespace AviBlog.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AviBlog.Core.Services.Search;

    public class SearchController : Controller
    {
        private readonly ISearchEngineService _searchEngineService;

        public SearchController(ISearchEngineService searchEngineService)
        {
            _searchEngineService = searchEngineService;
        }

        public ActionResult Query(string q)
        {
            IEnumerable<SearchEngineResult> result =
                _searchEngineService.Search(q, 50).Where(x => ! string.IsNullOrEmpty(x.Slug)).Distinct();
            return View(result);
        }
    }
}