using Lucene.Net.Util;

namespace AviBlog.Web.App_Start
{
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Snowball;

    public class SingletonAnalyzer
    {
        private static volatile Analyzer _instance;

        private static readonly object SyncRoot = new object();

        private SingletonAnalyzer() {}

        public static Analyzer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SnowballAnalyzer(Version.LUCENE_30,  "English");
                        }
                    }
                }
                return _instance;
            }
        }
    }
}