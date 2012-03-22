using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AviBlog.Core.ActionResults;
using AviBlog.Core.Services;

namespace AviBlog.Web.Controllers
{
    public class SiteMapController : Controller
    {
        private readonly IPostService _postService;

        public SiteMapController(IPostService postService)
        {
            _postService = postService;
        }

        public SiteMapResult Xml()
        {
            var posts =
                _postService.GetAllPostForBlog().Posts.Where(x => x.IsPublished && x.DatePublished.HasValue).ToList();

            return new SiteMapResult(posts);
        }
    }
}
