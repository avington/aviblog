using System.Collections.Generic;

namespace AviBlog.Core.ViewModel
{
    public class PostListViewModel
    {
        public int BlogId { get; set; }
        public IList<PostViewModel> Posts { get; set; }
    }
}