using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IGoodreadsService
    {
        GoodReadsUserShowViewModel GetGoodReadsTimeline(int take);
    }
}