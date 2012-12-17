namespace AviBlog.Web.V2.App_Start
{
    using AutoMapper;

    using AviBlog.Core.Mappings;

    public class BootstrapperAutoMapper
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(
                x =>
                    {
                        x.AddProfile(new UserMapperProfile());
                        x.AddProfile(new UserRoleMapperProfile());
                        x.AddProfile(new BlogSiteMapperProfile());
                        x.AddProfile(new PostMapperProfile());
                        x.AddProfile(new SettingMappingProfile());
                        x.AddProfile(new PingServiceMappingProfile());
                    });
        }
    }
}