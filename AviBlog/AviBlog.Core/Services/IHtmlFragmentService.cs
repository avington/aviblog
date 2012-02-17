using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IHtmlFragmentService
    {
        HtmlFragmentViewModel GetViewModel(int blogId);
        string AddHtmlFragement(HtmlFragmentViewModel viewModel);

        string DeleteById(int id);
        HtmlFragmentViewModel GetHtmlFragment(int id);
        string UpdateHtmlFragment(HtmlFragmentViewModel viewModel);
    }
}