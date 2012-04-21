using System.Collections.Generic;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public interface IBlogsSiteMappingService
    {
        BlogSiteViewModel MapToView(Blog blog);
        Blog MapToEntity(BlogSiteViewModel view);
    }
}