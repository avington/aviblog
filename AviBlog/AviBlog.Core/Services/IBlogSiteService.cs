using System.Collections.Generic;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IBlogSiteService
    {
        IList<BlogSiteViewModel> GetBlogsAll();
        BlogSiteViewModel GetBlogById(int id);
        string AddBlog(BlogSiteViewModel view);
        string DeleteBlog(int id);
        string SaveBlog(BlogSiteViewModel view);
    }
}