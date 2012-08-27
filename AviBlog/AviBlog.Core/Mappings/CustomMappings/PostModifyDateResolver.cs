using AutoMapper;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class PostModifyDateResolver : ValueResolver<Post, string>
    {
        protected override string ResolveCore(Post source)
        {
            return source.DateModified.HasValue ? source.DateModified.Value.ToShortDateString() : string.Empty;
        }
    }
}