using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class BlogSiteService : IBlogSiteService
    {
        private readonly IBlogSiteRepository _blogSiteRepository;
        private readonly IBlogsSiteMappingService _mappingService;

        public BlogSiteService(IBlogSiteRepository blogSiteRepository, IBlogsSiteMappingService mappingService)
        {
            _blogSiteRepository = blogSiteRepository;
            _mappingService = mappingService;
        }

        #region IBlogSiteService Members

        public IList<BlogSiteViewModel> GetBlogsAll()
        {
            List<Blog> blogs = _blogSiteRepository.GetAllBlogs().ToList();
            return blogs.Select(blog => _mappingService.MapToView(blog)).ToList();
        }

        public BlogSiteViewModel GetFirstPrimarySiteBlog()
        {
            var entity = _blogSiteRepository
                .GetAllBlogs()
                .FirstOrDefault(x => x.IsPrimary);

            if (entity == null) return new BlogSiteViewModel();
            return _mappingService.MapToView(entity);
        }

        public BlogSiteViewModel GetBlogById(int id)
        {
            var entity = _blogSiteRepository
                .GetAllBlogs()
                .FirstOrDefault(x => x.Id == id);
            
            if (entity == null) return new BlogSiteViewModel();

            return _mappingService.MapToView(entity);
        }

        public string AddBlog(BlogSiteViewModel view)
        {
            Blog blog = _mappingService.MapToEntity(view);
            return _blogSiteRepository.Add(blog);
        }

        public string DeleteBlog(int id)
        {
            return _blogSiteRepository.DeleteBlog(id);
        }

        public string SaveBlog(BlogSiteViewModel view)
        {
            Blog blog = _mappingService.MapToEntity(view);
            return _blogSiteRepository.Save(blog);
        }

        #endregion
    }
}