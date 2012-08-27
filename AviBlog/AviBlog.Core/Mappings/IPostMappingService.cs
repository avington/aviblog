using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public interface IPostMappingService
    {
        Post MapToEntity(PostViewModel viewModel);

        PostViewModel MapToView(Post entity);
    }
}