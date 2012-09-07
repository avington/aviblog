using System;
using System.IO;
using System.Web;

namespace AviBlog.Core.Application
{
    public class HttpHelper : IHttpHelper
    {
        #region IHttpHelper Members

        public string GetCookieValue(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            return cookie != null ? cookie.Value : string.Empty;
        }

        public string GetCurrentUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public string GetPath(string virtualDir, string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;
            if (string.IsNullOrEmpty(virtualDir)) return string.Empty;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(virtualDir), fileName);
            return path;
        }

        public string MapPath(string virtualPath)
        {
            return HttpContext.Current.Server.MapPath(virtualPath);
        }

        public string DecodeUrl(string urlEncodedText)
        {
            if (string.IsNullOrEmpty(urlEncodedText)) return string.Empty;
            return HttpContext.Current.Server.UrlDecode(urlEncodedText);
        }

        public Uri GetUrl(string slug)
        {
            string url = string.Format("{0}/Posts/Post/{1}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), slug);
            return new Uri(url);
        }

        public T GetSession<T>(string key)
        {
            object result =  HttpContext.Current.Session[key] ?? null;
            if (result == null) return default(T);
            return (T) result;
        }

        public void AddSession(string key, object obj)
        {
            HttpContext.Current.Session.Add(key,obj);
        }

        #endregion
    }
}