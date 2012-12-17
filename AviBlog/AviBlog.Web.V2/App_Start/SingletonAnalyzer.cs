using Lucene.Net.Util;

namespace AviBlog.Web.V2.App_Start
{
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Snowball;

    public class SingletonAnalyzer
    {
        private static volatile Analyzer instance;
        private static readonly object SyncRoot = new object();

        private SingletonAnalyzer() {}

        public static Analyzer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SnowballAnalyzer(Version.LUCENE_30, "English");
                        }
                    }
                }
                return instance;
            }
        }
    }
}