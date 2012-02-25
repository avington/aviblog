using System.Web.Mvc;

namespace AviBlog.Core.ViewModel
{
    public class ImportViewModel
    {
        public SelectList BlogSiteList { get; set; }
        public int SelectedBlogSite { get; set; }

        public SelectList UserList { get; set; }
        public int SelectedUserId { get; set; }
    }
}