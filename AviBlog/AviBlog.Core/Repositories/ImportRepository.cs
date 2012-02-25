using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class ImportRepository : IImportRepository
    {
        private readonly BlogContext _context;

        public ImportRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }

        public string ImportPosts(IList<Post> importPosts, int blogId, int userId)
        {
            if (importPosts == null) return "There were no posts to import.";

            //clear all the current posts for this blog
            var posts = _context.Posts.Where(x => x.Blog.Id == blogId).ToList();
            foreach (Post post in posts)
            {
                var tempTags = post.Tags.ToList();
                foreach ( var tag in tempTags)
                {
                    _context.Tags.Remove(tag);
                    _context.SaveChanges();
                }
                var tempCategories = post.Categories.ToList();
                foreach (var cat in tempCategories)
                {
                    post.Categories.Remove(cat);
                    _context.SaveChanges();
                }
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
            

            Blog blog = _context.Blogs.Find(blogId);
            UserProfile user = _context.UserProfiles.Find(userId);

            foreach (Post post in importPosts)
            {
                if (post.Categories != null)
                {
                    ICollection<Category> tempCat = post.Categories.ToList();
                    post.Categories.Clear();
                    foreach (Category category in tempCat)
                    {
                        Category categoryToAdd = _context.Categories.Any(x => x.CategoryName == category.CategoryName)
                                                     ? _context.Categories.First(x => x.CategoryName == category.CategoryName)
                                                     : new Category {CategoryName = category.CategoryName};
                        if (post.Categories != null) post.Categories.Add(categoryToAdd);
                    }

                    post.Tags = new Collection<Tag>();
                    foreach (Category category in tempCat)
                    {
                        post.Tags.Add(new Tag{TagName = category.CategoryName});
                    }
                }

                post.Blog = blog;
                post.User = user;
                _context.Posts.Add(post);
            }
            _context.SaveChanges();
            return string.Empty;
        }
    }
}