using System.Collections.Generic;

namespace AviBlog.Core.ViewModel
{
    public class PostListViewModel : BaseViewModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public IList<PostViewModel> Posts { get; set; }

        public string SubHead { get; set; }

        public object UserFullName { get; set; }

        public string Tag { get; set; }
    }
}