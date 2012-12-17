namespace AviBlog.Core.Services.Search
{
    using System;

    using AviBlog.Core.Entities;

    public class IndexingError
    {
        private readonly Post _post;

        private readonly Exception _exception;

        public IndexingError(Post post, Exception exception)
        {
            _post = post;
            _exception = exception;
        }

        public Post Post
        {
            get
            {
                return _post;
            }
        }

        public Exception Exception
        {
            get
            {
                return _exception;
            }
        }
    }
}