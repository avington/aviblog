using AutoMapper;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class PostCreateDateResolver : ValueResolver<Post, string>
    {
        protected override string ResolveCore(Post source)
        {
            return source.DateCreated.ToShortDateString();
        }
    }
}