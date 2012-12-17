namespace AviBlog.Core.Services.Search
{
    using System.Collections.Generic;

    public interface ISearchIndexService
    {
        List<IndexingError> RebuildIndex();
    }
}