using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public interface ISettingMappingService
    {
        Setting ToEntity(SettingViewModel viewModel);
        SettingViewModel ToView(Setting entity);
    }
}