using System.Collections.Generic;
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
        string Add(Post entity, int userId, int blogId);
        string Edit(Post post, int sectedUserId, int selectedBlogId);
        IQueryable<Tag> GetAllTags();
    }
}