using System;

namespace AviBlog.Core.Application
{
    public interface IHttpHelper
    {
        string GetCookieValue(string key);
        string GetCurrentUserName();
        string GetPath(string virtualDir, string fileName);
        string MapPath(string virtualPath);
        string DecodeUrl(string urlEncodedText);
        Uri GetUrl(string slug);
        T GetSession<T>(string key);
        void AddSession(string key, object obj);
    }
}