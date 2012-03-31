using System;
using System.Net;
using System.Text;
using System.Xml;
using Elmah;

namespace AviBlog.Core.Application
{
    public class PingWebRequestHelper : IPingWebRequestHelper
    {
         
        public void Send(string serviceUrl, string postUrl, string blogName)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(serviceUrl);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                var stream = request.GetRequestStream();
                using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("methodCall");
                    writer.WriteElementString("methodName", "weblogUpdates.ping");
                    writer.WriteStartElement("params");
                    writer.WriteStartElement("param");
                    writer.WriteElementString("value", blogName);
                    writer.WriteEndElement();
                    writer.WriteStartElement("param");
                    writer.WriteElementString("value", postUrl);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                request.GetResponse();

            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(new NotSupportedException());
            }
        }
    }
}