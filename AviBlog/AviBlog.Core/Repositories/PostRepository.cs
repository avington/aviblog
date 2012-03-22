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
            return _context.Posts.Find(id);
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
            Post post = _context.Posts.Find(id);
            if (post == null) return "Specified post was not found.";
            post.IsDeleted = true;
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string Add(Post post, int userId, int blogId)
        {
            var slugExists = _context.Posts.Any(x => x.Slug == post.Slug);
            if (slugExists)
                return "The slug that was created already exists. Modify your title.";


            UserProfile user = _context.UserProfiles.Find(userId);
            if (user != null) post.User = user;

            Blog blog = _context.Blogs.Find(blogId);
            post.Blog = blog;

            _context.Posts.Add(post);
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string Edit(Post post, int sectedUserId, int selectedBlogId)
        {
            var slugExists = _context.Posts.First(x => x.Slug == post.Slug);
            if (slugExists !=null && slugExists.Id != post.Id)
                return "The slug that was created already exists. Modify your title.";

            UserProfile user = _context.UserProfiles.Find(sectedUserId);
            Blog blog = _context.Blogs.Find(selectedBlogId);

            Post updatedPost = _context.Posts.Find(post.Id);
            if (updatedPost == null) return "The specified post could not be found.";

            updatedPost.Tags.Clear();
            _context.SaveChanges();

            updatedPost.Blog = blog;
            updatedPost.DateModified = post.DateModified;
            updatedPost.DatePublished = post.DatePublished;
            updatedPost.Description = post.Description;
            updatedPost.IsDeleted = post.IsDeleted;
            updatedPost.IsPublished = post.IsPublished;
            updatedPost.PostContent = post.PostContent;
            updatedPost.Tags = post.Tags;
            updatedPost.Slug = post.Slug;
            updatedPost.User = user;
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public IQueryable<Tag> GetAllTags()
        {
            return _context.Tags.AsQueryable();
        }
    }
}