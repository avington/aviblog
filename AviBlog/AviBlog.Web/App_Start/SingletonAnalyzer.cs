namespace AviBlog.Web.App_Start
{
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Snowball;

    public class SingletonAnalyzer
    {
        private static volatile Analyzer instance;

        private static readonly object syncRoot = new object();

        private SingletonAnalyzer() {}

        public static Analyzer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SnowballAnalyzer("English");
                        }
                    }
                }
                return instance;
            }
        }
    }
}