using AutoMapper;
using AviBlog.Core.Entities;
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
        }
    }
}