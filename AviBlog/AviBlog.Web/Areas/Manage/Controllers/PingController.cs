using System.Collections.Generic;
using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class PingController : Controller
    {
        private readonly IPingServiceService _pingServiceService;

        public PingController(IPingServiceService pingServiceService)
        {
            _pingServiceService = pingServiceService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            IList<PingServiceViewModel> list = _pingServiceService.GetAllPingServices();
            return View(list);
        }

        [AdminAuthorize]
        public JsonResult Submit(string pingId, string pingUrl)
        {
            int id;
            if (int.TryParse(pingId, out id))
                id = 0;

            if (string.IsNullOrEmpty(pingUrl))
                return Json(new {Status = false, Message = "The input paramter was null"}, JsonRequestBehavior.AllowGet);

            string errorMessage = id > 0
                                      ? _pingServiceService.Edit(new PingServiceViewModel {Id = id, PingUrl = pingUrl})
                                      : _pingServiceService.Add(pingUrl);

            bool status = (string.IsNullOrEmpty(errorMessage));
            return Json(new {Status = status, ErrorMessage = errorMessage}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            string errorMessage = _pingServiceService.Delete(id);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            ViewBag.ErrorMessage = errorMessage;
            IList<PingServiceViewModel> list = _pingServiceService.GetAllPingServices();
            return View("Index", list);
        }
    }
}