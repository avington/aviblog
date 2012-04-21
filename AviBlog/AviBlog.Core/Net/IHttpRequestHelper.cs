using System.Net;

namespace AviBlog.Core.Net
{
    public interface IHttpRequestHelper
    {
        string GetResponse(HttpWebRequest request);
        HttpWebRequest GetRequest(string fullUrl, string authorizationHeaderParams, string method);
    }
}