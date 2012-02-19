using AutoMapper;
using AviBlog.Core.Helpers;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class SlugResolver : ValueResolver<PostViewModel,string>
    {
        protected override string ResolveCore(PostViewModel source)
        {
            if (source == null || string.IsNullOrEmpty(source.Title)) return string.Empty;
            return source.Title.ToSlug();
        }
    }
}