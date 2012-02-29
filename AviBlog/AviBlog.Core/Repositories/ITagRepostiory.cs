using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface ITagRepostiory
    {
        IQueryable<Tag> GetAllTags();
    }
}