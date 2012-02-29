using System;
using System.Web.Mvc;
using AviBlog.Core.Services;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ITagService _tagService;

        public TagsController(IPostService postService, ITagService tagService)
        {
            _postService = postService;
            _tagService = tagService;
        }

        public ActionResult Tag(string id)
        {
            PostListViewModel postList = _postService.GetAllPostsForTag(id);
             return View(postList);
         }

        public ActionResult TagCloud()
        {
            var view = _tagService.GetTagCloud();
            return PartialView("_TagCloud",view);
        }
    }
}