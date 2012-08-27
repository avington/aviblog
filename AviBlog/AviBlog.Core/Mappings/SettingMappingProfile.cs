using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class SettingMappingProfile : Profile
    {
         public const string ViewModel = "SettingProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<Setting, SettingViewModel>();

            CreateMap<SettingViewModel, Setting>();

        }
    }
}