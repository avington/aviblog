using System.IO;
using System.Text;
using System.Xml;

namespace AviBlog.Core.Application
{
    public class StreamHelper : IStreamHelper
    {
         public XmlTextReader StringToXmlReader(string path)
         {
             string xml = File.ReadAllText(path);
             byte[] byteArray = Encoding.UTF8.GetBytes(xml);
             var stream = new MemoryStream(byteArray);
             var xmlStream = new XmlTextReader(stream);
             return xmlStream;
         }
    }
}