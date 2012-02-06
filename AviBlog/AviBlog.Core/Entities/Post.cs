using System;
using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual UserProfile User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsPublished { get; set; }
        public string Slug { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Trackback> Trackbacks { get; set; } 
    }
}