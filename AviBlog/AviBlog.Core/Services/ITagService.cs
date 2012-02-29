using System.Collections.Generic;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface ITagService
    {
        IList<TagCloudViewModel> GetTagCloud();
    }
}