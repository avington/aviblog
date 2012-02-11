using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
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
                               BlogName = "Steven Moseley's Ruminations",
                               IsActive = true,
                               IsPrimary = true,
                               HostName = "www.avingtonsolutions.com/aviblog",
                               SubHead = "About that art of writing code, plus other minutiae"
                           };
            var fragment = new HtmlFragment
                               {
                                   Name = "Google Analytics",
                                   ScriptBody = "<script type=\"text/javascript\"></script>"
                               };
            var user = new UserProfile
                           {
                               FirstName = "Steven",
                               LastName = "Moseley",
                               Email = "avington12345@msn.com",
                               UserName = "admin",
                               Password = password,
                               Blog = blog
                           };

            var users = new List<UserProfile> {user};
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
                                   CategoryName = "Test",
                                   Posts = posts
                               };
            var locations = new List<HtmlFragmentLocation>
                                {
                                    new HtmlFragmentLocation
                                        {
                                            LocationName = "Head",
                                        },
                                    new HtmlFragmentLocation
                                        {
                                            LocationName = "Top of body",
                                        },
                                    new HtmlFragmentLocation
                                        {
                                            LocationName = "Bottom of body",
                                        },
                                    new HtmlFragmentLocation
                                        {
                                            LocationName = "Right Pannel",
                                        }


                                };
            HtmlFragmentLocation head = locations.First(x => x.LocationName == "Head");
            fragment.Location = head;
            blog.HtmlFragments = new Collection<HtmlFragment> {fragment};
            context.Blogs.Add(blog);
            context.Posts.Add(post);
            context.UserProfiles.Add(user);           
            context.Categories.Add(category);
            context.UserRoles.Add(roleAdmin);
            context.UserRoles.Add(roleUser);
            foreach (HtmlFragmentLocation location in locations)
            {
                context.HtmlFragmentLocations.Add(location);
            }
            
            base.Seed(context);
        }
    }
}