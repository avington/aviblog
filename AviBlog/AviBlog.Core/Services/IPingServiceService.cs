using System.Collections.Generic;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IPingServiceService
    {
        PingServiceViewModel GetPingService(int id);
        IList<PingServiceViewModel> GetAllPingServices();
        string  Add(string pingUrl);
        string Edit(PingServiceViewModel viewModel);
        string Delete(int id);
    }
}