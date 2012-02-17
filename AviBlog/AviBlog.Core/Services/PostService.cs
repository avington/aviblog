using System;
using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostMappingService _postMappingService;
        private readonly IPostRepository _postRepository;
        private readonly IBlogSiteRepository _blogSiteRepository;

        public PostService(IPostRepository postRepository, IBlogSiteRepository blogSiteRepository, IPostMappingService postMappingService)
        {
            _postRepository = postRepository;
            _blogSiteRepository = blogSiteRepository;
            _postMappingService = postMappingService;
        }

        public PostListViewModel GetPosts(string blogId)
        {
            int id;
            if (!int.TryParse(blogId,out id))
            id = 0;
            Blog blog = _blogSiteRepository.GetAllBlogs()
                            .FirstOrDefault(x => x.Id == id) ?? _blogSiteRepository.GetAllBlogs()
                                                                    .FirstOrDefault(x => x.IsPrimary);
            var view = new PostListViewModel();
            if (blog == null) return view;

            view.BlogId = blog.Id;
            var posts = _postRepository.GetAllPosts();
            view.Posts = new List<PostViewModel>();
            foreach (Post post in posts)
            {
                var item = _postMappingService.MapToView(post);
                view.Posts.Add(item);
            }
            throw new NotImplementedException();
        }
    }

    
}