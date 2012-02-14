using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using AviBlog.Core.ActionFilters;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Areas.Manage.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IProfileUserService _userService;

        public ProfileController(IAuthenticationService authenticationService, IProfileUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            IList<UserViewModel> users = _userService.GetAllUsers();
            return View(users);
        }

        public ActionResult SignIn()
        {
            var signInView = new SignInViewModel();
            return View(signInView);
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel view)
        {
            bool auth = _authenticationService.AuthenticateUser(view);
            if (auth) return RedirectToActionPermanent("Index");
            return View(new SignInViewModel());
        }

        public ActionResult Create()
        {
            var userView = new UserViewModel();
            return View(userView);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Create(UserViewModel user)
        {
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                result = _userService.AddUser(user);
                if (string.IsNullOrEmpty(result))
                {
                    var routeValues = new RouteValueDictionary();
                    routeValues.Add("userName", user.UserName);
                    return RedirectToActionPermanent("roles", routeValues);
                }
            }
            user.ErrorMessage = result;
            return View(user);
        }

        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            UserViewModel userView = _userService.GetUserById(id);
            userView.Password = string.Empty;
            userView.ConfirmPassword = string.Empty;
            return View(userView);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Edit(UserViewModel viewModel)
        {
            string errorMessage = _userService.UpdateUser(viewModel);
            if (string.IsNullOrEmpty(errorMessage))
                return RedirectToActionPermanent("Index");
            viewModel.ErrorMessage = errorMessage;
            return View(viewModel);
        }

        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            string errorMessage = _userService.DeleteUserById(id);
            var users = _userService.GetAllUsers();
            if (string.IsNullOrEmpty(errorMessage))
            {               
                ViewBag.ErrorMessage = errorMessage;
            }
            return View("Index", users);
        }

        [AdminAuthorize]
        public ActionResult Roles(string userName)
        {
            UserRolesViewModel viewModel = _userService.GetUserRoles(userName);
            return View("UserRoles", viewModel);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Roles(UserRolesViewModel view)
        {
            string errorMessage = _userService.UpdateUserRoles(view);
            var list = _userService.GetAllUsers();
            return string.IsNullOrEmpty(errorMessage) ? View("Index",list) : View("UserRoles", view);
        }

        [AdminAuthorize]
        public ActionResult EditRoles(int id)
        {
            UserRolesViewModel viewModel = _userService.GetUserRolesById(id);
            return View("UserRoles", viewModel);
        }
    }
}