using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class PingServiceMappingService : IPingServiceMappingService
    {
         public PingServiceViewModel MapToView(PingService entity)
         {
             return Mapper.Map<PingService, PingServiceViewModel>(entity);
         }

        public PingService MapToEntity(PingServiceViewModel view)
        {
            return Mapper.Map<PingServiceViewModel, PingService>(view);
        }
    }
}