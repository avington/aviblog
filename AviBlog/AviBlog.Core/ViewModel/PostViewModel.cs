using System;
using System.Collections.Generic;


namespace AviBlog.Core.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsPublished { get; set; }
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IList<CategoryViewModel> Categories { get; set; }
        public virtual IList<TagViewModel> Tags { get; set; }
        public virtual IList<TrackbackViewModel> Trackbacks { get; set; } 
    }
}