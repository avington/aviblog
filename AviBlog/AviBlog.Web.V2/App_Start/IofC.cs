namespace AviBlog.Web.V2.App_Start
{
    using StructureMap;

    public class IofC
    {
        public static void InitializeStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new AviBlogRegistry()));
        }
    }
}