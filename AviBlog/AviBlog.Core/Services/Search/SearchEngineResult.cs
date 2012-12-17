namespace AviBlog.Core.Services.Search
{
    using System;

    public class SearchEngineResult
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime DatePublished { get; set; }

        public float Score { get; set; }

        public string Slug { get; set; }

        public DateTime DatePublishUtc { get; set; }

    }
}