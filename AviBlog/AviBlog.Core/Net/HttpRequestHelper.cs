using System;
using System.IO;
using System.Net;

namespace AviBlog.Core.Net
{
    public class HttpRequestHelper : IHttpRequestHelper
    {
        public string GetResponse(HttpWebRequest request)
        {
            ServicePointManager.Expect100Continue = false;

            if (request != null)
                using (var response = request.GetResponse() as HttpWebResponse)
                {

                    try
                    {
                        if (response != null && response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApplicationException(
                                string.Format("The request did not compplete successfully and returned status code:{0}",
                                              response.StatusCode));
                        }
                        if (response != null)
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                return reader.ReadToEnd();
                            }
                    }
                    catch (WebException exception)
                    {
                        return exception.Message;
                    }
                }
            return "The request is null";
        }


        public HttpWebRequest GetRequest(string fullUrl, string authorizationHeaderParams, string method)
        {
            var hwr = (HttpWebRequest)WebRequest.Create(fullUrl);
            if (! string.IsNullOrEmpty(authorizationHeaderParams)) hwr.Headers.Add("Authorization", authorizationHeaderParams);
            hwr.Method = method;
            hwr.Timeout = 3 * 60 * 1000;
            return hwr;
        }
    }
}