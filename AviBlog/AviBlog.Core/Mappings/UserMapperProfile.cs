using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class UserMapperProfile : Profile
    {
        public const string ViewModel = "UserProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<UserProfile, UserViewModel>()
                .ForMember(dest => dest.ConfirmPassword,opt => opt.Ignore())
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore())
                ;


            CreateMap<UserViewModel, UserProfile>()
                .ForMember(dest => dest.Blog,opt => opt.Ignore())
                .ForMember(dest => dest.Roles,opt => opt.Ignore());

        }
    }
}