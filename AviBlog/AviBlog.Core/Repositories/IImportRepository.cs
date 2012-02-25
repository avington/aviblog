using System.Collections.Generic;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface IImportRepository
    {
        string ImportPosts(IList<Post> importPosts, int blogId, int userId);
    }
}