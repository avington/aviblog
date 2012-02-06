using StructureMap.Configuration.DSL;

namespace AviBlog.Web.App_Start
{
    public class AviBlogRegistry : Registry
    {
        public AviBlogRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.Assembly("AviBlog.Core");
                         x.WithDefaultConventions();
                     });
        }
    }
}