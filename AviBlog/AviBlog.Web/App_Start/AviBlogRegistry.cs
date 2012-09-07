namespace AviBlog.Web.App_Start
{
    using AviBlog.Core.Services.Search;
    using StructureMap.Configuration.DSL;

    public class AviBlogRegistry : Registry
    {
        #region Constructors and Destructors

        public AviBlogRegistry()
        {
            Scan(
                x =>
                    {
                        x.TheCallingAssembly();
                        x.Assembly("AviBlog.Core");
                        x.WithDefaultConventions();
                    });

            //Register Search and Indexing Services
            For<ISearchEngineService>().Singleton().Use(
                () => new SearchEngineService(SingletonDirectory.Instance, SingletonAnalyzer.Instance));
            For<ISearchIndexService>().Singleton().Use<SearchIndexService>();
        }

        #endregion
    }
}