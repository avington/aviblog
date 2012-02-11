using System.Collections.Generic;
using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class BlogsSiteMappingService : IBlogsSiteMappingService
    {
        public BlogSiteViewModel MapToView(Blog blog)
        {
            var view = Mapper.Map<Blog, BlogSiteViewModel>(blog);
            return view;
        }

        public Blog MapToEntity(BlogSiteViewModel view)
        {
            var entity = Mapper.Map<BlogSiteViewModel, Blog>(view);
            return entity;
        }
    }
}