using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IPostService
    {
        PostListViewModel GetPosts(string blogId);
    }
}