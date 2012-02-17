using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface IPostRepository
    {
        Post GetPostById(int id);
        IQueryable<Post> GetAllPosts();
        string Edit(Post post);
        string Delete(int id);
        string Add(Post id);
    }
}