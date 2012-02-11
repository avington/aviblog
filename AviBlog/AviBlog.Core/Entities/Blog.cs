using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string SubHead { get; set; }
        public string HostName { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<HtmlFragment> HtmlFragments { get; set; }
    }
}