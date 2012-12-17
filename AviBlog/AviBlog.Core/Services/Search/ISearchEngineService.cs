namespace AviBlog.Core.Services.Search
{
    using System;
    using System.Collections.Generic;

    using AviBlog.Core.Entities;

    public interface ISearchEngineService
    {

        IEnumerable<IndexingError> AddPost(Post post);

        IEnumerable<IndexingError> AddPosts(IEnumerable<Post> posts);

        IEnumerable<IndexingError> AddPosts(IEnumerable<Post> posts, bool optimize);

        void Dispose();

        IEnumerable<SearchEngineResult> Search(string queryString, int max);

        IEnumerable<SearchEngineResult> Search(string queryString, int max, int entryId);

        void RemovePost(int postId);

        
    }
}