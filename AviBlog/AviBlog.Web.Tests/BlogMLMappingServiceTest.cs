using System;
using AviBlog.Core.Mappings;
using BlogML;
using BlogML.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AviBlog.Web.Tests
{
    [TestClass]
    public class BlogMLMappingServiceTest
    {

        private BlogMLMappingService _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new BlogMLMappingService();
        }
             

        [TestMethod]
        public void Should_be_able_to_map_a_blogml_object_to_the_post_list_view()
        {

            BlogMLBlog blogMl = BuildBlogML();
            var result = _target.MapToEntity(blogMl);
            Assert.IsNotNull(result);
        }

        private BlogMLBlog BuildBlogML()
        {
            var mlBlog = new BlogMLBlog();
            var author = new BlogMLAuthor {Title = "admin"};
            mlBlog.Authors.Add(author);
            var cat = new BlogMLCategory {Title = "Title 1", ID = "1"};
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 2", ID = "2" };
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 3", ID = "3" };
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 4", ID = "4" };
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 5", ID = "5" };
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 6", ID = "6" };
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 7", ID = "7" };
            mlBlog.Categories.Add(cat);
            cat = new BlogMLCategory { Title = "Title 8", ID = "8" };
            mlBlog.Categories.Add(cat);

            var mlPost = new BlogMLPost();
            mlPost.Categories.Add("1");
            mlPost.Approved = true;
            mlPost.Content = new BlogMLContent {ContentType = ContentTypes.Text, Text = "post 1"};
            mlPost.DateCreated = new DateTime(2012, 2, 2);
            mlPost.DateModified = new DateTime(2012, 2, 2);
            mlPost.Excerpt = new BlogMLContent { ContentType = ContentTypes.Text, Text = "post 1" };
            mlPost.HasExcerpt = true;
            mlPost.ID = "1";
            mlPost.PostName = "name 1";
            mlPost.PostType = BlogPostTypes.Normal;
            var trackback = new BlogMLTrackback
                                            {
                                                Approved = true,
                                                DateCreated = new DateTime(2012, 2, 2),
                                                DateModified = new DateTime(2012, 2, 2),
                                                ID = "2",
                                                Title = "trackback title 2",
                                                Url = "url2"
                                            };
            mlPost.Trackbacks.Add(trackback);
            mlPost.Title = "Title 1";
            mlPost.Views = 0;
            mlBlog.Posts.Add(mlPost);

            mlPost = new BlogMLPost();
            mlPost.Categories.Add("1");
            mlPost.Approved = true;
            mlPost.Content = new BlogMLContent { ContentType = ContentTypes.Text, Text = "post 3" };
            mlPost.DateCreated = new DateTime(2032, 3, 3);
            mlPost.DateModified = new DateTime(2032, 3, 3);
            mlPost.Excerpt = new BlogMLContent { ContentType = ContentTypes.Text, Text = "post 3" };
            mlPost.HasExcerpt = true;
            mlPost.ID = "3";
            mlPost.PostName = "name 3";
            mlPost.PostType = BlogPostTypes.Normal;
            trackback = new BlogMLTrackback
            {
                Approved = true,
                DateCreated = new DateTime(2032, 3, 3),
                DateModified = new DateTime(2032, 3, 3),
                ID = "3",
                Title = "trackback title 3",
                Url = "url1"
            };
            mlPost.Trackbacks.Add(trackback);
            mlPost.Title = "Title 2";
            mlPost.Views = 0;
            mlBlog.Posts.Add(mlPost);


            return mlBlog;

        }
    }
}