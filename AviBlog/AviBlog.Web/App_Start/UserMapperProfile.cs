using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Web.App_Start
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
                .ForMember(dest => dest.ConfirmPassword,opt => opt.Ignore());

        }
    }
}