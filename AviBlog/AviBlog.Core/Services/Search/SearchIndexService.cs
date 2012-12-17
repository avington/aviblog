namespace AviBlog.Core.Services.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using AviBlog.Core.Repositories;

    public class SearchIndexService : ISearchIndexService
    {
        private readonly IPostRepository _postRepository;

        private readonly ISearchEngineService _searchEngineService;

        public SearchIndexService(IPostRepository postRepository, ISearchEngineService searchEngineService)
        {
            _postRepository = postRepository;
            _searchEngineService = searchEngineService;
        }

        public List<IndexingError> RebuildIndex()
        {
            var posts = _postRepository.GetAllPosts().Where(x => x.IsPublished && !x.IsDeleted);
            List<IndexingError> errors = _searchEngineService.AddPosts(posts).ToList();
            return errors;
        }
    }
}