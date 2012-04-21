using System.Web.Mvc;
using Newtonsoft.Json;

namespace AviBlog.Core.Helpers
{
    public static class JavaScriptSerializerHelper
    {

        public static MvcHtmlString ToJson(this object model)
        {
            string json = JsonConvert.SerializeObject(model);
            return new MvcHtmlString(json);
        }
         
    }
}