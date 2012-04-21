using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IGoodReadsXmlMappingService
    {
        GoodReadsUserShowViewModel MapToViewModel(string xml);
    }
}