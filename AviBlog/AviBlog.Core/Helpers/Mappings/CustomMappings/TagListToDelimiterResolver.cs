using System.Linq;
using AutoMapper;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class TagListToDelimiterResolver : ValueResolver<Post, string>
    {
        protected override string ResolveCore(Post source)
        {
            if (source == null) return string.Empty;
            if (source.Tags == null) return string.Empty;
            string tagDelimited = source.Tags.Aggregate(string.Empty,
                                                        (current, tag) => current + string.Format("{0},", tag.TagName));

            return !string.IsNullOrEmpty(tagDelimited)
                       ? tagDelimited.Substring(0, tagDelimited.Length - 1)
                       : tagDelimited;
        }
    }
}