namespace AviBlog.Core.Helpers
{
    using System;
    using System.Configuration;
    using System.Web.Mvc;

    using SquishIt.Framework;
    using SquishIt.Framework.Css;

    public static class SquishItHelper
    {
        public static MvcHtmlString PackageCss(this HtmlHelper helper)
        {
            CSSBundle client =
                Bundle.Css().Add("~/Content/fonts/cantarell/stylesheet.css").Add("~/content/reset.css").Add(
                    "~/content/home.css");

            return IsCompressed()
                       ? new MvcHtmlString(client.ForceRelease().Render("~/content/combined_#.css"))
                       : new MvcHtmlString(client.ForceDebug().Render("~/content/combined_#.css"));
        }

        private static bool IsCompressed()
        {
            return ConfigurationManager.AppSettings["CompressStaticFiles"].Equals(
                "true", StringComparison.CurrentCultureIgnoreCase);
        }

        public static MvcHtmlString PackageHeaderJs(this HtmlHelper helper)
        {
            string client =
                Bundle.JavaScript()
                    .Add("~/Scripts/underscore.min.js")
                    .Add("~/Scripts/backbone.min.js")
                    .Add("~/Scripts/jQuery.tmpl.min.js")
                    .Add("~/Scripts/modernizr-2.5.3.js")
                    .ForceRelease()
                    .Render("~/Scripts/combinedHead_#.js");

            return new MvcHtmlString(client);
        }

        public static MvcHtmlString PackageFooterJs(this HtmlHelper helper)
        {
            string client = Bundle.JavaScript()
                .Add("~/js/search.js")  
                .ForceRelease()
                .Render("~/js/conbinedFoot.js");

            return new MvcHtmlString(client);
        }
    }
}