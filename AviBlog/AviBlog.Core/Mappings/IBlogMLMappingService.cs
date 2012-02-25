using System.Collections.Generic;
using AviBlog.Core.Entities;
using BlogML.Xml;

namespace AviBlog.Core.Mappings
{
    public interface IBlogMLMappingService
    {
        IList<Post> MapToEntity(BlogMLBlog blogML);
    }
}