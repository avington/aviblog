using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.ActionResults
{
    public class RssResult : FileResult
    {
        private readonly PostListViewModel _view;
        private SyndicationFeed _feed;
        public RssResult(PostListViewModel model)
            : base("application/rss+xml")
        {
            _view = model;
            if (_view == null) return;
            _feed = new SyndicationFeed(_view.BlogTitle, _view.SubHead, HttpContext.Current.Request.Url, BuildItems());
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            using (XmlWriter writer = XmlWriter.Create(response.OutputStream))
            {
                _feed.GetRss20Formatter().WriteTo(writer);
            }
        }

        private IEnumerable<SyndicationItem> BuildItems()
        {
            if (_view == null) return new BindingList<SyndicationItem>();
            var list = new List<SyndicationItem>();
            var posts = _view.Posts.Take(10);
            foreach (var post in posts)
            {
                var item = new SyndicationItem(post.Title, post.PostContent, GetUrl(post.Slug),
                                               post.UniqueId.ToString(), GetLastUpdateTime(post.DatePublished));
                list.Add(item);
            }

            return list;
        }

        private DateTimeOffset GetLastUpdateTime(DateTime? datePublished)
        {
            var dateVal = (datePublished.HasValue ? datePublished.Value : DateTime.MinValue);
            DateTimeOffset offset = DateTime.SpecifyKind(dateVal, DateTimeKind.Local);
            return offset;
        }

        private Uri GetUrl(string slug)
        {
            string url = string.Format("{0}/Posts/Post/{1}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), slug);
            return new Uri(url);
        }
    }
}