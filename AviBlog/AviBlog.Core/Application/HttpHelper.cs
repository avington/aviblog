using System;
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

        #endregion
    }
}