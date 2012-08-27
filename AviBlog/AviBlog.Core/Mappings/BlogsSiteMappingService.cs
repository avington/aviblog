using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class BlogsSiteMappingService : IBlogsSiteMappingService
    {
        private readonly IHtmlFragmentMappingService _htmlFragmentMappingService;

        public BlogsSiteMappingService(IHtmlFragmentMappingService htmlFragmentMappingService)
        {
            _htmlFragmentMappingService = htmlFragmentMappingService;
        }

        public BlogSiteViewModel MapToView(Blog blog)
        {
            BlogSiteViewModel view = Mapper.Map<Blog, BlogSiteViewModel>(blog);
            if (view.HtmlFragments == null) view.HtmlFragments = new List<HtmlFragmentViewModel>();
            foreach (var htmlFragment in blog.HtmlFragments)
            {
                var html = _htmlFragmentMappingService.MapToView(htmlFragment);
                if (!view.HtmlFragments.Any(x => x.Id == htmlFragment.Id)) view.HtmlFragments.Add(html);
            }
            return view;
        }

        public Blog MapToEntity(BlogSiteViewModel view)
        {
            var entity = Mapper.Map<BlogSiteViewModel, Blog>(view);
            return entity;
        }
    }
}