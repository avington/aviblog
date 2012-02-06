using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using AviBlog.Core.Context;
using AviBlog.Core.Encryption;
using AviBlog.Core.Entities;

namespace AviBlog.Web.Tests.Initializers
{
    public class BlogDbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var enc = new EncryptionHelper();
            string password = enc.Encrypt("admin");
            var blog = new Blog
                           {
                               BlogName = "Test blog",
                               IsActive = true,
                               IsPrimary = true,
                               HostName = "host",
                               SubHead = "seb head"
                           };
            var user = new UserProfile
                           {
                               FirstName = "Patton",
                               LastName = "Manning",
                               Email = "test@test.com",
                               UserName = "admin",
                               Password = password,
                               Blog = blog
                           };
            var users = new List<UserProfile>();
            users.Add(user);
            var roleAdmin = new UserRole
                                {
                                    RoleName = "Admin",
                                    UserProfiles = users
                                };
            var roleUser = new UserRole
                               {
                                   RoleName = "Aviblog User"
                               };
            var tags = new List<Tag> { new Tag{ TagName = "tag" }};
            var post = new Post
                           {
                               Blog = blog,
                               DateCreated = DateTime.Now,
                               DateModified = DateTime.Now,
                               Description = "description",
                               IsDeleted = false,
                               IsPublished = true,
                               PostContent = "post content",
                               Title = "title",
                               User = user,
                               Slug = "slug",
                               Tags = tags
                           };
            
            var posts = new List<Post> {post};
            var category = new Category
                               {
                                   CategoryName = "category name",
                                   Posts = posts
                               };
            
            context.Blogs.Add(blog);
            context.UserProfiles.Add(user);
            context.Posts.Add(post);
            context.Categories.Add(category);
            context.UserRoles.Add(roleAdmin);
            context.UserRoles.Add(roleUser);
            base.Seed(context);
        }
    }
}