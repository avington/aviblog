using System;
using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings.CustomMappings;
using AviBlog.Core.ViewModel;


namespace AviBlog.Core.Mappings
{
    public class BlogSiteMapperProfile : Profile
    {
        public const string ViewModel = "BlogSiteProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<Blog, BlogSiteViewModel>()
                .ForMember(dest => dest.BlogId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ErrorMessage,opt => opt.Ignore());

            CreateMap<BlogSiteViewModel, Blog>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.BlogId))
                ;

            CreateMap<HtmlFragmentViewModel, HtmlFragment>()
                .ForMember(dest => dest.Blogs, opt => opt.Ignore())
                .ForMember(dest => dest.Location,
                           opt => opt.MapFrom(x => new HtmlFragmentLocation {Id = Convert.ToInt32( x.SelectedLocationId)}));
                ;

            CreateMap<HtmlFragment, HtmlFragmentViewModel>()
                .ForMember(dest => dest.BlogId, opt => opt.Ignore())
                .ForMember(dest => dest.LocationList, opt => opt.Ignore())
                .ForMember(dest => dest.ErrorMessage,opt => opt.Ignore())
                .ForMember(dest => dest.SelectedLocationId, opt => opt.Ignore())
                .ForMember(dest => dest.SelectedLocationName, opt => opt.ResolveUsing<LocationTagResolver>())
                ;


        }
    }
}