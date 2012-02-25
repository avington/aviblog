﻿using System.Web.Mvc;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult Index()
        {
            const int top = 5;
            PostListViewModel viewModel = _postService.GetTopMostRecentPosts(top);

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}