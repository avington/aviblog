using AutoMapper;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class SelectedBlogIdResolver : ValueResolver<Post,int>
    {
        protected override int ResolveCore(Post source)
        {
            if (source == null) return 0;
            if (source.Blog == null) return 0;
            return source.Blog.Id;
        }
    }
}