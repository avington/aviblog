namespace AviBlog.Web.V2.App_Start
{
    using System;
    using System.IO;
    using System.Web;

    using Lucene.Net.Store;

    using Directory = Lucene.Net.Store.Directory;

    public sealed class SingletonDirectory
    {
        private static volatile Directory instance;

        private static readonly object syncRoot = new Object();

        private SingletonDirectory()
        {
        }

        public static Directory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null && HttpContext.Current != null)
                            instance = 
                                FSDirectory.Open(
                                    new DirectoryInfo(HttpContext.Current.Server.MapPath("~/App_data/lucene_search/")));
                    }
                }
                return instance;
            }
        }
    }
}