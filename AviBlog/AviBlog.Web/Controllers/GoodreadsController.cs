using System;
using System.Web.Mvc;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;
using Elmah;

namespace AviBlog.Web.Controllers
{
    public class GoodreadsController : Controller
    {
        private readonly IGoodreadsService _goodreadsService;

        public GoodreadsController(IGoodreadsService goodreadsService)
        {
            _goodreadsService = goodreadsService;
        }

        [HttpGet]
        public JsonResult Client(string id)
        {
            var result = GetGoodReadsUserShowViewModel(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 6000, VaryByParam = "*")]
        public ActionResult Index(string id)
        {
            try
            {
                GoodReadsUserShowViewModel result = GetGoodReadsUserShowViewModel(id);
                return PartialView("_Goodreads", result);
            }
            catch(Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return PartialView("_Goodreads", new GoodReadsUserShowViewModel {ErrorMessage = ex.Message});
            }
        }
        
        private GoodReadsUserShowViewModel GetGoodReadsUserShowViewModel(string id)
        {
            int take;
            if (int.TryParse(id, out take))
                take = 5;

            GoodReadsUserShowViewModel result = _goodreadsService.GetGoodReadsTimeline(take);
            return result;
        }
    }
}