using System.Collections.Generic;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface ISettingsService
    {
        SettingViewModel GetSettingByKey(string key );
        string AddSetting(SettingViewModel setting);
        string EditSetting(SettingViewModel setting);
        string DeleteSetting(int id);
        IList<SettingViewModel> GetAllSettings();
        SettingViewModel GetSettingById(int id);
    }
}