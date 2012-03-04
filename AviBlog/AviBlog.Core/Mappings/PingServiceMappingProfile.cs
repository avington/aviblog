using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class PingServiceMappingProfile : Profile
    {
        public const string ViewModel = "PingServiceProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<PingService, PingServiceViewModel>()
                ;

            CreateMap<PingServiceViewModel, PingService>()
                ;
        }
    }
}