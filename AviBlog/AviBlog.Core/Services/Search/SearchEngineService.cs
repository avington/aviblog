using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AviBlog.Core.Entities;
using AviBlog.Core.Helpers;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Version = Lucene.Net.Util.Version;

namespace AviBlog.Core.Services.Search
{
    public class SearchEngineService : ISearchEngineService
    {
        private const string Body = "Body";

        private const string IsPublished = "IsPublished";

        private const string PostId = "PostId";

        private const string DatePublished = "DatePublished";

        private const string Title = "Title";

        private const string Slug = "Slug";

        private const string Tags = "Tags";

        private const string MetaDescription = "MetaDescription";

        private static IndexWriter _writer;

        private static readonly Object WriterLock = new Object();

        private readonly Analyzer _analyzer;

        private readonly Directory _directory;

        private bool _disposed;

        public SearchEngineService(Directory directory, Analyzer analyzer)
        {
            _directory = directory;
            _analyzer = analyzer;
        }

        private IndexSearcher Searcher
        {
            get { return DoWriterAction(indexWriter => new IndexSearcher(indexWriter.GetReader())); }
        }

        #region ISearchEngineService Members

        public IEnumerable<IndexingError> AddPost(Post post)
        {
            return AddPosts(new[] {post}, false);
        }

        public IEnumerable<IndexingError> AddPosts(IEnumerable<Post> posts)
        {
            return AddPosts(posts, true);
        }

        public IEnumerable<IndexingError> AddPosts(IEnumerable<Post> posts, bool optimize)
        {
            var errors = new List<IndexingError>();
            foreach (Post post in posts.ToList())
            {
                RemovePostFromIndex(post.Id);
                try
                {
                    Post currentPost = post;
                    DoWriterAction(indexWriter => indexWriter.AddDocument(CreateDocument(currentPost)));
                }
                catch (Exception ex)
                {
                    errors.Add(new IndexingError(post, ex));
                }
            }
            DoWriterAction(
                indexWriter =>
                    {
                        indexWriter.Commit();
                        if (optimize) indexWriter.Optimize();
                    });
            return errors;
        }

        public void Dispose()
        {
            lock (WriterLock)
            {
                if (_disposed) return;
                IndexWriter indexWriter = _writer;
                if (indexWriter != null) indexWriter.Dispose();
                Directory directory = _directory;
                if (directory != null) directory.Dispose();
                _disposed = true;
            }
        }

        public IEnumerable<SearchEngineResult> Search(string queryString, int max)
        {
            return Search(queryString, max, -1);
        }

        public IEnumerable<SearchEngineResult> Search(string queryString, int max, int entryId)
        {
            var list = new List<SearchEngineResult>();
            if (string.IsNullOrEmpty(queryString)) return list;

            var parser = new QueryParser(Version.LUCENE_29, Body, _analyzer);
            //parser.SetDefaultOperator(QueryParser.Operator.OR);

            queryString = queryString.RemoveSpecialLuceneCharactors();

            //build the query string
            Query bodyQuery = parser.Parse(queryString);
            if (string.IsNullOrEmpty(bodyQuery.ToString())) return list;
            string tagQuery = bodyQuery.ToString().Replace(Body, Tags);
            string titleQuery = bodyQuery.ToString().Replace(Body, Title);
            string queryStringMerged = String.Format("({0}) OR ({1}) OR ({2})", bodyQuery, titleQuery, tagQuery);

            Query query = parser.Parse(queryStringMerged);

            return PerformQuery(list, query, max, entryId);
        }

        public void RemovePost(int postId)
        {
            ExecuteRemovePost(postId);
            DoWriterAction(indexWriter => indexWriter.Commit());
        }

        #endregion

        private Document CreateDocument(Post post)
        {
            var tagDelimited = new StringBuilder();
            foreach (Tag tag in post.Tags) tagDelimited.AppendFormat("{0},", tag.TagName);
            if (tagDelimited.Length > 0) tagDelimited.Remove(tagDelimited.Length - 1, 1);

            string pubDate = post.DatePublished.HasValue
                                 ? post.DatePublished.Value.DateToStringInMinutes()
                                 : DateTime.MinValue.DateToStringInMinutes();

            var doc = new Document();

            //create the fields
            var postId = new Field(
                PostId,
                NumericUtils.IntToPrefixCoded(post.Id),
                Field.Store.YES,
                Field.Index.NOT_ANALYZED,
                Field.TermVector.NO);

            var title = new Field(
                Title,
                post.Title,
                Field.Store.YES,
                Field.Index.ANALYZED,
                Field.TermVector.YES);

            var body = new Field(
                Body,
                post.PostContent,
                Field.Store.NO,
                Field.Index.ANALYZED,
                Field.TermVector.YES);

            var tags = new Field(
                Tags,
                tagDelimited.ToString(),
                Field.Store.NO,
                Field.Index.ANALYZED,
                Field.TermVector.YES);

            var metaDescirption = new Field(
                MetaDescription,
                post.Description ?? string.Empty,
                Field.Store.NO,
                Field.Index.ANALYZED,
                Field.TermVector.YES
                );

            var published = new Field(
                IsPublished,
                post.IsPublished.ToString(),
                Field.Store.NO,
                Field.Index.NOT_ANALYZED,
                Field.TermVector.NO);

            var slug = new Field(
                Slug,
                post.Slug,
                Field.Store.YES,
                Field.Index.NO,
                Field.TermVector.NO);

            var pubdate = new Field(
                DatePublished,
                pubDate,
                Field.Store.YES,
                Field.Index.NOT_ANALYZED,
                Field.TermVector.NO);

            //boost some of the entries
            title.Boost = 4;
            tags.Boost = 2;
            body.Boost = 1;
            slug.Boost = 2;
            metaDescirption.Boost = 1;

            //add the fields to the docuement
            doc.Add(postId);
            doc.Add(title);
            doc.Add(body);
            doc.Add(tags);
            doc.Add(published);
            doc.Add(pubdate);
            doc.Add(slug);
            doc.Add(metaDescirption);

            return doc;
        }

        private void DoWriterAction(Action<IndexWriter> action)
        {
            lock (WriterLock)
            {
                EnsureWriterInstance();
            }
            action(_writer);
        }

        private T DoWriterAction<T>(Func<IndexWriter, T> action)
        {
            lock (WriterLock)
            {
                EnsureWriterInstance();
            }
            return action(_writer);
        }

        private void EnsureWriterInstance()
        {
            if (_writer != null) return;

            if (IndexWriter.IsLocked(_directory)) IndexWriter.Unlock(_directory);

            _writer = new IndexWriter(_directory, _analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            _writer.SetMergePolicy(new LogDocMergePolicy(_writer));
            //_writer.SetMergeFactor(5);
        }

        private Query GetQueryFromId(int id)
        {
            return new TermQuery(new Term(id.ToString(CultureInfo.InvariantCulture), NumericUtils.IntToPrefixCoded(id)));
        }

        private void RemovePostFromIndex(int id)
        {
            Query qry = GetQueryFromId(id);
            DoWriterAction(x => x.DeleteDocuments(qry));
        }

        private IEnumerable<SearchEngineResult> PerformQuery(
            List<SearchEngineResult> list, Query queryOrig, int max, int idToFilter)
        {
            Query isPublishedQuery = new TermQuery(new Term(IsPublished, true.ToString()));

            var query = new BooleanQuery();
            query.Add(isPublishedQuery, Occur.MUST);
            query.Add(queryOrig, Occur.MUST);

            IndexSearcher searcher = Searcher;
            TopDocs hits = searcher.Search(query, max);
            int length = hits.ScoreDocs.Length;
            int resultsAdded = 0;
            const float minScore = 0.1f;
            float scoreNorm = 1.0f/hits.MaxScore;
            
            for (int i = 0; i < length && resultsAdded < max; i++)
            {
                if (hits.ScoreDocs == null) continue;
                float score = hits.ScoreDocs[i].Score*scoreNorm;
                SearchEngineResult result = CreateSearchResult(searcher.Doc(hits.ScoreDocs[i].Doc), score);
                if (idToFilter == result.PostId || !(result.Score > minScore) || result.DatePublished >= DateTime.UtcNow
                    || list.Any(x => x.Title == result.Title)) continue;
                list.Add(result);
                resultsAdded++;
            }
            return list;
        }

        private SearchEngineResult CreateSearchResult(Document doc, float score)
        {
            string id = doc.Get(PostId);
            string date = doc.Get(DatePublished);
            var result = new SearchEngineResult
                {
                    PostId = NumericUtils.PrefixCodedToInt(id),
                    DatePublished = DateTools.StringToDate(date),
                    Title = doc.Get(Title),
                    Score = score,
                    Slug = doc.Get(Slug)
                };

            return result;
        }

        private void ExecuteRemovePost(int postId)
        {
            Query searchQuery = GetIdSearchQuery(postId);

            DoWriterAction(indexWriter => indexWriter.DeleteDocuments(searchQuery));
        }

        private Query GetIdSearchQuery(int postId)
        {
            return new TermQuery(new Term(PostId, NumericUtils.IntToPrefixCoded(postId)));
        }
    }
}