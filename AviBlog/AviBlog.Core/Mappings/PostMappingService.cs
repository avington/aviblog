using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class PostMappingService : IPostMappingService
    {
        public Post MapToEntity(PostViewModel viewModel)
        {
            return Mapper.Map<PostViewModel, Post>(viewModel);
        }

        public PostViewModel MapToView(Post entity)
        {
            return Mapper.Map<Post, PostViewModel>(entity);
        }
    }
}