using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingMappingService _settingMappingService;
        private readonly ISettingRepository _settingRepository;

        public SettingsService(ISettingMappingService settingMappingService, ISettingRepository settingRepository)
        {
            _settingMappingService = settingMappingService;
            _settingRepository = settingRepository;
        }

        #region ISettingsService Members

        public SettingViewModel GetSettingByKey(string key)
        {
            Setting entity = _settingRepository.GetAll().FirstOrDefault(x => x.Key == key);
            SettingViewModel view = _settingMappingService.ToView(entity);
            return view;
        }

        public string AddSetting(SettingViewModel setting)
        {
            Setting entity = _settingMappingService.ToEntity(setting);
            string errorMessage = _settingRepository.Add(entity);
            return errorMessage;
        }

        public string EditSetting(SettingViewModel setting)
        {
            Setting entity = _settingMappingService.ToEntity(setting);
            string errorMessage = _settingRepository.Edit(entity);
            return errorMessage;
        }

        public string DeleteSetting(int id)
        {
            return _settingRepository.Delete(id);
        }

        public IList<SettingViewModel> GetAllSettings()
        {
            List<Setting> settings = _settingRepository.GetAll().ToList();
            return settings.Select(setting => _settingMappingService.ToView(setting)).ToList();
        }

        public SettingViewModel GetSettingById(int id)
        {
            var entity = _settingRepository.FindById(id);
            var view = _settingMappingService.ToView(entity);
            return view;
        }

        #endregion
    }
}