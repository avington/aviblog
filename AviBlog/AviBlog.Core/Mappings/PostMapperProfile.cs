using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class PostMapperProfile : Profile
    {

        public const string ViewModel = "PostProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.UserName,opt => opt.Ignore())
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore() )
                .ForMember(dest => dest.Trackbacks, opt => opt.Ignore())
                ;

            CreateMap<PostViewModel, Post>()
                .ForMember(dest => dest.Blog, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.Trackbacks, opt => opt.Ignore())
                ;
        }
         
    }
}