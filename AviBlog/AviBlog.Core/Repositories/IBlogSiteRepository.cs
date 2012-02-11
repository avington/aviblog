using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface IBlogSiteRepository
    {

        IQueryable<Blog> GetAllBlogs();

        string Add(Blog blog);
        string DeleteBlog(int id);
        string Save(Blog blog);
    }
}