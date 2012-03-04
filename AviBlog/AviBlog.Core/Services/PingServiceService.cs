using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class PingServiceService : IPingServiceService
    {
        private readonly IPingRepository _pingRepository;
        private readonly IPingServiceMappingService _pingServiceMappingService;

        public PingServiceService(IPingServiceMappingService pingServiceMappingService, IPingRepository pingRepository)
        {
            _pingServiceMappingService = pingServiceMappingService;
            _pingRepository = pingRepository;
        }

        public PingServiceViewModel GetPingService(int id)
        {
            PingService entity = _pingRepository.GetById(id);
            return _pingServiceMappingService.MapToView(entity);
        }

        public IList<PingServiceViewModel> GetAllPingServices()
        {
            var entities = _pingRepository.GetAll().ToList();
            return entities.Select(pingService => _pingServiceMappingService.MapToView(pingService)).ToList();
        }

        public string  Add(string pingUrl)
        {
            return _pingRepository.Add(new PingService {PingUrl = pingUrl});
        }

        public string Edit(PingServiceViewModel viewModel)
        {
            var entity = _pingServiceMappingService.MapToEntity(viewModel);
            return _pingRepository.Update(entity);
        }

        public string Delete(int id)
        {
            return _pingRepository.Delete(id);
        }
    }
}