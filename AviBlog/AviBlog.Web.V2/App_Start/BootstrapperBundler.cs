namespace AviBlog.Web.V2.App_Start
{
    using System;
    using System.Configuration;
    using System.Web.Optimization;

    public class BootstrapperBundler
    {
        public static void Bundle()
        {
            bool isMinimized = Convert.ToBoolean(ConfigurationManager.AppSettings["CompressStaticFiles"]);

            var fonts = InitializeBundleCss("~/content/fonts", isMinimized);
            fonts.AddFile("~/Styles/fonts/BEBASNEUE/stylesheet.css");
            fonts.AddFile("~/Styles/fonts/cantarell/stylesheet.css");
            fonts.AddFile("~/Styles/fonts/chunkfive/stylesheet.css");
            fonts.AddFile("~/Styles/fonts/heydings_icons/stylesheet.css");
            fonts.AddFile("~/Styles/fonts/MonospaceTypewriter/stylesheet.css");
            BundleTable.Bundles.Add(fonts);
            

            var scripts = InitializeBundleJs("~/Scripts/js", isMinimized);
            scripts.AddDirectory("~/Scripts/a", "*.js");
            scripts.AddDirectory("~/Scripts/b", "*.js");
            BundleTable.Bundles.Add(scripts);

            var css = InitializeBundleCss("~/styles/css", isMinimized);
            css.AddDirectory("~/Content", "*.css");
            css.AddDirectory("~/Styles", "*.css");


            BundleTable.Bundles.Add(css);
        }

        private static Bundle InitializeBundleJs(string virtualPath, bool minimize)
        {
            if (minimize)
            {
                IBundleTransform transform = new JsMinify();
                var jsMin = new Bundle(virtualPath, transform);
                return jsMin;
            }
            var js = new Bundle(virtualPath);
            return js;
        }

        private static Bundle InitializeBundleCss(string virtualPath, bool minimize)
        {
            if (minimize)
            {
                IBundleTransform transform = new CssMinify();
                var cssMin = new Bundle(virtualPath, transform);
                return cssMin;
            }
            var css = new Bundle(virtualPath);
            return css;
        }
  

    }
}