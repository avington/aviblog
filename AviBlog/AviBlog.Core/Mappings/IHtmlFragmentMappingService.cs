using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public interface IHtmlFragmentMappingService
    {
        HtmlFragment MapToEntity(HtmlFragmentViewModel viewModel);
        HtmlFragmentViewModel MapToView(HtmlFragment entity);
    }
}