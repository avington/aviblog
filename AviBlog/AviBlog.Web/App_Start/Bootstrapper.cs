using System.Web.Mvc;
using AutoMapper;
using AviBlog.Core.Mappings;
using StructureMap;

namespace AviBlog.Web.App_Start
{
    public class Bootstrapper
    {

        public static void InitializeStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new AviBlogRegistry()));
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                                  {
                                      x.AddProfile(new UserMapperProfile());
                                      x.AddProfile(new UserRoleMapperProfile());
                                      x.AddProfile(new BlogSiteMapperProfile());
                                      x.AddProfile(new PostMapperProfile());
                                      x.AddProfile(new SettingMappingProfile());
                                  });;
        }
    }
}