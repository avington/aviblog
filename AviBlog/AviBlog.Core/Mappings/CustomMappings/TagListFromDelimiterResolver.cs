using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class TagListFromDelimiterResolver : ValueResolver<PostViewModel,IList<Tag>>
    {
        protected override IList<Tag> ResolveCore(PostViewModel source)
        {
            if (source == null) return new List<Tag>();
            if (string.IsNullOrEmpty(source.TagListCommaDelimited)) return new List<Tag>();
            var tags = source.TagListCommaDelimited.Split(char.Parse(","));
            var list = tags.Select(tag => new Tag {TagName = tag}).ToList();
            return list;
        }
    }
}