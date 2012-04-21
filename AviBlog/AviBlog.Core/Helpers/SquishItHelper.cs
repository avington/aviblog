using System.Web.Mvc;
using SquishIt.Framework;

namespace AviBlog.Core.Helpers
{
    public static class SquishItHelper
    {
        public static MvcHtmlString PackageCss(this HtmlHelper helper)
        {
            var client = Bundle.Css()
                .Add("~/Content/fonts/cantarell/stylesheet.css")
                .Add("~/Content/fonts/cantarell/stylesheet.css")
                .Add("~/content/reset.css")
                .Add("~/content/home.css")
                .Render("~/content/combined_#.css")
                ;
            
            return new MvcHtmlString(client);
        }
         
    }
}