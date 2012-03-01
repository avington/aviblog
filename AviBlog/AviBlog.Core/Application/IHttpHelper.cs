namespace AviBlog.Core.Application
{
    public interface IHttpHelper
    {
        string GetCookieValue(string key);
        string GetCurrentUserName();
        string GetPath(string virtualDir, string fileName);
        string DecodeUrl(string urlEncodedText);
    }
}