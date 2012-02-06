using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class HeadScript
    {
        public int Id { get; set; }
        public virtual ICollection<Blog> Blogs  { get; set; }
        public string ScriptBody { get; set; }
    }
}