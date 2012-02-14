using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class HtmlFragmentMappingService : IHtmlFragmentMappingService
    {
         public HtmlFragment MapToEntity(HtmlFragmentViewModel viewModel)
         {
             return Mapper.Map<HtmlFragmentViewModel,HtmlFragment >(viewModel);
         }

         public HtmlFragmentViewModel MapToView(HtmlFragment entity)
         {
             return Mapper.Map<HtmlFragment,HtmlFragmentViewModel >(entity);
         }
    }
}