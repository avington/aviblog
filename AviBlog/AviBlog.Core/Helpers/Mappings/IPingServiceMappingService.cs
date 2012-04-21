using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public interface IPingServiceMappingService
    {
        PingServiceViewModel MapToView(PingService entity);
        PingService MapToEntity(PingServiceViewModel view);
    }
}