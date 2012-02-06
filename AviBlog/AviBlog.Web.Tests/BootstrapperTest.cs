using AutoMapper;
using AviBlog.Web.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AviBlog.Web.Tests
{
    [TestClass]
    public class BootstrapperTest
    {

        [TestMethod]
        public void Should_be_able_to_configure_user_profile_to_view()
        {
            Bootstrapper.RegisterMappings();
            Mapper.AssertConfigurationIsValid();
        }
         
    }
}