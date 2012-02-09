using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var users = _userService.GetAllUsers();
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
        public ActionResult Create(UserViewModel user)
        {
            string result= string.Empty;
            if (ModelState.IsValid)
            {
                 result = _userService.AddUser(user);
                if (string.IsNullOrEmpty(result))
                {
                    var routeValues = new RouteValueDictionary();
                    routeValues.Add("userName",user.UserName);
                    return RedirectToActionPermanent("roles", routeValues);
                }
            }
            user.ErrorMessage = result;
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Roles(string userName)
        {
            UserRolesViewModel viewModel = _userService.GetUserRoles(userName);
            return View("UserRoles", viewModel);
        }

        [HttpPost]
        public ActionResult Roles(UserRolesViewModel view)
        {
            return View();
        }
    }
}
