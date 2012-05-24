using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AviBlog.Core.Application;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IBlogSiteRepository _blogSiteRepository;
        private readonly IBlogsSiteMappingService _blogsSiteMappingService;
        private readonly IHttpHelper _helper;
        private readonly IHttpHelper _httpHelper;
        private readonly IPingHttpPostService _pingHttpPostService;
        private readonly IPostMappingService _postMappingService;
        private readonly IPostRepository _postRepository;
        private readonly IProfileUserRepository _profileUserRepository;

        public PostService(IPostRepository postRepository, IBlogSiteRepository blogSiteRepository,
                           IPostMappingService postMappingService, IHttpHelper httpHelper,
                           IProfileUserRepository profileUserRepository, IHttpHelper helper,
                           IBlogsSiteMappingService blogsSiteMappingService, IPingHttpPostService pingHttpPostService)
        {
            _postRepository = postRepository;
            _blogSiteRepository = blogSiteRepository;
            _postMappingService = postMappingService;
            _httpHelper = httpHelper;
            _profileUserRepository = profileUserRepository;
            _helper = helper;
            _blogsSiteMappingService = blogsSiteMappingService;
            _pingHttpPostService = pingHttpPostService;
        }

        #region IPostService Members

        public PostListViewModel GetAllPostForBlog()
        {
            Blog blog = GetCurrentBlog();
            var view = new PostListViewModel();
            if (blog == null) return view;

            view.BlogId = blog.Id;
            view.BlogTitle = blog.BlogName;
            List<Post> posts = _postRepository.GetAllPosts().ToList();
            view.Posts = new List<PostViewModel>();
            foreach (Post post in posts)
            {
                PostViewModel item = _postMappingService.MapToView(post);
                view.Posts.Add(item);
            }
            return view;
        }

        public string FlagPostAsDeleted(int id)
        {
            return _postRepository.Delete(id);
        }

        public PostViewModel GetNewPostViewModel()
        {
            var view = new PostViewModel();

            //get selected user and userlist
            string userName = _httpHelper.GetCurrentUserName();
            UserProfile cUser =
                _profileUserRepository.GetUserProfiles()
                    .FirstOrDefault(x => x.UserName == userName);

            int userId = 0;
            if (cUser != null) userId = cUser.Id;

            IEnumerable<UserViewModel> users = GetUserList();

            view.UserList = new SelectList(users, "Id", "UserName", userId);

            //get the selected blog and blog list
            Blog blog = GetCurrentBlog();
            view.SelectedBlog = _blogsSiteMappingService.MapToView(blog);

            //get blog list
            IEnumerable<BlogSiteViewModel> blogList = GetBlogList();

            //IList<BlogSiteViewModel> blogList = blogs.Select(b => _blogsSiteMappingService.MapToView(b)).ToList();
            view.BlogList = new SelectList(blogList, "BlogId", "BlogName", blog.Id);

            view.DateCreated = DateTime.Now;
            view.DateModified = DateTime.Now;

            return view;
        }

        public string AddPost(PostViewModel post)
        {
            post.DateCreated = DateTime.Now;
            post.DateModified = DateTime.Now;
            SetPublishDate(post);
            Post entity = _postMappingService.MapToEntity(post);
            entity.UniqueId = Guid.NewGuid();

            string result = _postRepository.Add(entity, post.SectedUserId, post.SelectedBlogId);

            SendPing(entity, result);

            return result;
        }

        public PostViewModel GetPostViewModelById(int id)
        {
            Post post = _postRepository.GetPostById(id);
            PostViewModel viewPost = _postMappingService.MapToView(post);

            //get blog list
            IEnumerable<BlogSiteViewModel> blogList = GetBlogList();
            viewPost.BlogList = new SelectList(blogList, "blogId", "BlogName", viewPost.SelectedBlogId);

            //get user list
            IEnumerable<UserViewModel> userList = GetUserList();
            viewPost.UserList = new SelectList(userList, "Id", "UserName", viewPost.SectedUserId);

            return viewPost;
        }

        public string EditPost(PostViewModel post)
        {
            post.DateModified = DateTime.Now;
            SetPublishDate(post);
            Post entity = _postMappingService.MapToEntity(post);

            if (entity.UniqueId.ToString() == "00000000-0000-0000-0000-000000000000")
                entity.UniqueId = Guid.NewGuid();

            string result = _postRepository.Edit(entity, post.SectedUserId, post.SelectedBlogId);
            SendPing(entity, result);
            return result;
        }

        public PostListViewModel GetTopMostRecentPosts(int top)
        {
            if (top == 0) top = 5;
            List<Post> posts = _postRepository.GetAllPosts()
                .Where(x => x.IsPublished && !x.IsDeleted && x.Blog.IsActive && x.Blog.IsPrimary)
                .Take(top)
                .OrderByDescending(x => x.DatePublished)
                .ToList();
            var viewModel = new PostListViewModel {Posts = new List<PostViewModel>()};
            if (posts.Count == 0)
            {
                viewModel.ErrorMessage = "No posts were found.";
                return viewModel;
            }
            Blog blog = posts.First().Blog;
            viewModel.BlogId = blog.Id;
            viewModel.BlogTitle = blog.BlogName;
            viewModel.SubHead = blog.SubHead;

            foreach (Post post in posts)
            {
                PostViewModel item = _postMappingService.MapToView(post);
                viewModel.Posts.Add(item);
            }

            return viewModel;
        }


        public PostListViewModel GetPostBySlug(string slug)
        {
            Post post =
                _postRepository.GetAllPosts().FirstOrDefault(
                    x => x.Slug == slug && x.Blog.IsActive && x.Blog.IsPrimary && !x.IsDeleted && x.IsPublished);
            if (post == null) return new PostListViewModel {ErrorMessage = "The specified post was not found."};

            var list = new PostListViewModel
                           {
                               BlogId = post.Blog.Id,
                               BlogTitle = post.Blog.BlogName,
                               SubHead = post.Blog.SubHead,
                               Posts = new List<PostViewModel>()
                           };
            PostViewModel item = _postMappingService.MapToView(post);
            item.Tags = MapTags(post);
            item.UserFullName = string.Format("{0} {1}", post.User.FirstName, post.User.LastName);
            list.Posts.Add(item);
            return list;
        }

        public PostListViewModel GetAllPostsForTag(string urlEncodedTag)
        {
            string tag = urlEncodedTag.Replace('+', ' ');
            List<Post> posts = _postRepository.GetAllPosts().Where(x => x.Tags.Any(y => y.TagName == tag))
                .Where(x => x.Blog.IsActive && x.Blog.IsPrimary && !x.IsDeleted && x.IsPublished)
                .OrderByDescending(x => x.DatePublished)
                .ToList();

            var list = new PostListViewModel {Posts = new List<PostViewModel>()};
            if (posts.Count == 0)
            {
                list.ErrorMessage = "The selected posts were not found.";
                return list;
            }


            Blog blog = posts.First().Blog;
            UserProfile user = posts.First().User;
            list.BlogId = blog.Id;
            list.BlogTitle = blog.BlogName;
            list.SubHead = blog.SubHead;
            list.UserFullName = user.FirstName + " " + user.LastName;
            foreach (Post post in posts)
            {
                PostViewModel item = _postMappingService.MapToView(post);
                item.Tags = MapTags(post);
                list.Posts.Add(item);
            }
            list.Tag = tag;
            return list;
        }

        #endregion

        private void SendPing(Post entity, string result)
        {
            //if post added is successful then ping all the services with the URL
            if (string.IsNullOrEmpty(result))
            {
                if (ConfigurationManager.AppSettings["PingService"].Equals("true"))
                    _pingHttpPostService.Ping(entity);
            }
        }

        private static void SetPublishDate(PostViewModel post)
        {
            if (post.IsPublished && post.UseCurrentDateTime)
                post.DatePublished = DateTime.Now;
            else if (post.IsPublished && !post.DatePublished.HasValue)
                post.DatePublished = DateTime.Now;
        }

        private IList<TagViewModel> MapTags(Post post)
        {
            return post.Tags.Select(item => new TagViewModel
                                                {
                                                    Id = item.Id,
                                                    Name = item.TagName
                                                }).ToList();
        }

        private IEnumerable<UserViewModel> GetUserList()
        {
            List<UserViewModel> users = _profileUserRepository
                .GetUserProfiles()
                .Where(x => x.IsActive)
                .Select(x => new UserViewModel {Id = x.Id, UserName = x.UserName})
                .ToList();
            return users;
        }

        private IEnumerable<BlogSiteViewModel> GetBlogList()
        {
            List<BlogSiteViewModel> blogList = _blogSiteRepository.GetAllBlogs()
                .Where(x => x.IsActive)
                .Select(x => new BlogSiteViewModel {BlogId = x.Id, BlogName = x.BlogName})
                .ToList()
                ;
            return blogList;
        }

        private Blog GetCurrentBlog()
        {
            string blogId = _helper.GetCookieValue("blog");
            int id;
            if (!int.TryParse(blogId, out id))
                id = 0;
            Blog blog = _blogSiteRepository.GetAllBlogs()
                            .FirstOrDefault(x => x.Id == id) ?? _blogSiteRepository.GetAllBlogs()
                                                                    .FirstOrDefault(x => x.IsPrimary);
            return blog;
        }
    }
}