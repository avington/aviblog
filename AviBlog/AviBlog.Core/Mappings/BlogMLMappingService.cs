using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Helpers;
using BlogML.Xml;

namespace AviBlog.Core.Mappings
{
    public class BlogMLMappingService : IBlogMLMappingService
    {
        public IList<Post> MapToEntity(BlogMLBlog blogML)
        {
            var list = new List<Post>();
            foreach (BlogMLPost blogMLPost in blogML.Posts)
            {
                var post = new Post();
                post.Categories = GetPostCategoryies(blogML.Categories, blogMLPost);
                post.DateCreated = blogMLPost.DateCreated;
                post.DateModified = blogMLPost.DateModified;
                post.IsPublished = true;
                post.DatePublished = blogMLPost.DateModified;
                if (blogMLPost.Excerpt != null) post.Description = blogMLPost.Excerpt.Text;
                post.IsDeleted = false;
                if (blogMLPost.Content != null) post.PostContent = blogMLPost.Content.Text;
                post.Slug = blogMLPost.Title.ToSlug();
                post.Title = blogMLPost.Title;
                Guid guid;
                if (!Guid.TryParse(blogMLPost.ID, out guid))
                    guid = Guid.NewGuid();
                post.UniqueId = guid;
                list.Add(post);
            }
            return list;
        }

        private ICollection<Category> GetPostCategoryies(BlogMLBlog.CategoryCollection categories, BlogMLPost blogMLPost)
        {
            var list = new List<Category>();
            if (blogMLPost == null || blogMLPost.Categories == null) return new Collection<Category>();
            for (int i = 0; i < blogMLPost.Categories.Count; i++)
            {
                string postCategoryId = blogMLPost.Categories[i].Ref;
                list.AddRange(from category in categories
                              where category.ID == postCategoryId
                              select new Category {CategoryName = category.Title});
            }
            return list;
        }
    }
}