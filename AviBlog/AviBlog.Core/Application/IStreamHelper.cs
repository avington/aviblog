using System.Xml;

namespace AviBlog.Core.Application
{
    public interface IStreamHelper
    {
        XmlTextReader StringToXmlReader(string path);
    }
}