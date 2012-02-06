using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public string CategoryName { get; set; }
    }
}