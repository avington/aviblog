using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class HtmlFragment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Blog> Blogs  { get; set; }
        public string ScriptBody { get; set; }
        public virtual HtmlFragmentLocation Location { get; set; }
        
    }
}