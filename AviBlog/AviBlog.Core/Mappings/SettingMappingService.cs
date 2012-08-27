using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class SettingMappingService : ISettingMappingService
    {
         public Setting ToEntity(SettingViewModel viewModel)
         {
             return Mapper.Map<SettingViewModel, Setting>(viewModel);
         }

        public SettingViewModel ToView(Setting entity)
        {
            return Mapper.Map<Setting, SettingViewModel>(entity);
        }
    }
}