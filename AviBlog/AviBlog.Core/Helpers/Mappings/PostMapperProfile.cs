using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings.CustomMappings;
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
                .ForMember(dest => dest.SectedUserId, opt => opt.ResolveUsing<SelectedUserIdResolver>())
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.Trackbacks, opt => opt.Ignore())
                .ForMember(dest => dest.TagListCommaDelimited, opt => opt.ResolveUsing<TagListToDelimiterResolver>())
                .ForMember(dest => dest.UserList,opt => opt.Ignore())
                .ForMember(dest => dest.SelectedBlog, opt => opt.Ignore())
                .ForMember(dest => dest.BlogList, opt => opt.Ignore())
                .ForMember(dest => dest.SelectedBlogId, opt => opt.ResolveUsing<SelectedBlogIdResolver>())
                .ForMember(dest => dest.UserFullName,opt => opt.Ignore())
                .ForMember(dest => dest.UseCurrentDateTime, opt => opt.Ignore())
                ;

            CreateMap<PostViewModel, Post>()
                .ForMember(dest => dest.Blog, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.ResolveUsing<TagListFromDelimiterResolver>())
                .ForMember(dest => dest.Trackbacks, opt => opt.Ignore())
                .ForMember(dest => dest.Slug, opt => opt.ResolveUsing<SlugResolver>())
                
                ;
        }
    }
}