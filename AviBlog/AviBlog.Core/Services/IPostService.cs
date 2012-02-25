using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IPostService
    {
        PostListViewModel GetAllPostForBlog();
        string FlagPostAsDeleted(int id);
        PostViewModel GetNewPostViewModel();
        string AddPost(PostViewModel post);
        PostViewModel GetPostViewModelById(int id);
        string EditPost(PostViewModel post);
        PostListViewModel GetTopMostRecentPosts(int top);
        PostListViewModel GetPostBySlug(string slug);
    }
}