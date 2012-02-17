using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }

        public Post GetPostById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _context.Posts.AsQueryable();
        }

        public string Edit(Post post)
        {
            throw new System.NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Add(Post id)
        {
            throw new System.NotImplementedException();
        }
    }
}