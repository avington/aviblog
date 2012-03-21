using System.Web.Mvc;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            var list = _settingsService.GetAllSettings();
            return View(list);
        }

        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            var view = _settingsService.GetSettingById(id);
            return View(view);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Edit(SettingViewModel viewModel)
        {
            string errorMessage = _settingsService.EditSetting(viewModel);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            ViewBag.ErrorMessage = errorMessage;
            return View(viewModel);
        }

        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            string errorMessage = _settingsService.DeleteSetting(id);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var list = _settingsService.GetAllSettings();
                ViewBag.ErrorMessage = errorMessage;
                return View("Index", list);
            }
            return RedirectToActionPermanent("Index");
        }

        [AdminAuthorize]
        public ActionResult Create()
        {
            var list = new SettingViewModel();
            return View(list);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Create(SettingViewModel viewModel)
        {
            string errorMessage = _settingsService.AddSetting(viewModel);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            ViewBag.ErrorMessage = errorMessage;
            return View(viewModel);
        }
    }
}