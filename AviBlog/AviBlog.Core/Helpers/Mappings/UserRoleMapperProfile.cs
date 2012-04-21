using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class UserRoleMapperProfile : Profile
    {
        public const string ViewModel = "UserRoleProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<UserRole, RolesViewModel>()
                .ForMember(dest => dest.RoleId,opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.IsChecked, opt => opt.Ignore());
        }
    }
}