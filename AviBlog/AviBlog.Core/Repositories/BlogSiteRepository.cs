using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class BlogSiteRepository : IBlogSiteRepository
    {
        private readonly BlogContext _context;

        public BlogSiteRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }

        public IQueryable<Blog> GetAllBlogs()
        {
            return _context.Blogs.AsQueryable();
        }

        public string Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return string.Empty;
        }

        public string DeleteBlog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            if (blog == null) return "The specified blog could not be found.";
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return string.Empty;
        }

        public string Save(Blog blog)
        {
            var temp = _context.Blogs.FirstOrDefault(x => x.Id == blog.Id);
            if (temp == null) return "The specified blog could not be found.";
            temp.BlogName = blog.BlogName;
            temp.HostName = blog.HostName;
            temp.IsActive = blog.IsActive;
            temp.IsPrimary = blog.IsPrimary;
            temp.SubHead = blog.SubHead;
            _context.SaveChanges();
            return string.Empty;
        }

        public Blog GetBlogId(int selectedBlogId)
        {
            return _context.Blogs.Find(selectedBlogId);
        }
    }
}