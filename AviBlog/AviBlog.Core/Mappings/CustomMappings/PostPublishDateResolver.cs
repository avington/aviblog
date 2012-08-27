using AutoMapper;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class PostPublishDateResolver : ValueResolver<Post, string>
    {
        protected override string ResolveCore(Post source)
        {
            return source.DatePublished.HasValue ? source.DatePublished.Value.ToShortDateString() : string.Empty;
        }
    }
}