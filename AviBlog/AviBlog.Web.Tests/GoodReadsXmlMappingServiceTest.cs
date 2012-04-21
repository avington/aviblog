using System.IO;
using AviBlog.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AviBlog.Web.Tests
{
    [TestClass]
    public class GoodReadsXmlMappingServiceTest
    {

        [TestMethod]
        public void should_be_able_to_map_goodreads_xml_to_view()
        {
            const string path = @"C:\github\aviblog\AviBlog\AviBlog.Web.Tests\3425042.xml";
            var ns = new GoodReadsXmlMappingService();
            var view = ns.MapToViewModel(File.ReadAllText(path));

            Assert.IsNotNull(view);
        }
    }
}