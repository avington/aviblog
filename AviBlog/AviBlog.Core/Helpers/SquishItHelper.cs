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
                .Add("~/content/reset.css")
                .Add("~/content/home.css")
                .ForceRelease()
                .Render("~/content/combined_#.css")
                ;
            
            return new MvcHtmlString(client);
        }

        public static MvcHtmlString PackageHeaderJs(this HtmlHelper helper)
        {
            var client = Bundle.JavaScript()
                .Add("~/Scripts/underscore.min.js")
                .Add("~/Scripts/backbone.min.js")
                .Add("~/Scripts/jQuery.tmpl.min.js")
                .Add("~/Scripts/modernizr-2.5.3.js")
                .ForceRelease()
                .Render("~/Scripts/combinedHead_#.js")
                ;

            return new MvcHtmlString(client);
        }
         
    }
}