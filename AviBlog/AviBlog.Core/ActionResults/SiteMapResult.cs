using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AviBlog.Core.Application;
using AviBlog.Core.ViewModel;
using StructureMap;

namespace AviBlog.Core.ActionResults
{
    public class SiteMapResult : FileResult
    {
        private readonly List<PostViewModel> _view;
        private readonly IHttpHelper _httpHelper;

        public SiteMapResult(List<PostViewModel> model)
            : base("text/xml")
        {
            _view = model;
            _httpHelper = ObjectFactory.GetInstance<IHttpHelper>();
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            using (var writer = XmlWriter.Create(response.OutputStream))
            {
                writer.WriteStartElement("urlset", "http://www.google.com/schemas/sitemap/0.84");
                // Posts
                foreach (var post in _view )
                {
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", _httpHelper.GetUrl(post.Slug).ToString());
                    if (post.DatePublished.HasValue)
                        writer.WriteElementString(
                            "lastmod", post.DatePublished.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                    writer.WriteElementString("changefreq", "monthly");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

            }
        }
    }
}