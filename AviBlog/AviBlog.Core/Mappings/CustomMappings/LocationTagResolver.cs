using AutoMapper;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Mappings.CustomMappings
{
    public class LocationTagResolver : ValueResolver<HtmlFragment, string>
    {
        protected override string ResolveCore(HtmlFragment source)
        {
            HtmlFragmentLocation item = source.Location;
            return item.LocationName;
        }
    }
}