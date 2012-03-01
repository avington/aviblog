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
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/blogml"), fileName);
            return path;
        }

        public string DecodeUrl(string urlEncodedText)
        {
            if (string.IsNullOrEmpty(urlEncodedText)) return string.Empty;
            return HttpContext.Current.Server.UrlDecode(urlEncodedText);
        }

        #endregion
    }
}