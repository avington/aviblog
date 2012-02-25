using System.Collections.Generic;
using System.Web;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IBlogMLService
    {
        string SaveAndImport(IList<HttpPostedFileBase> files, ImportViewModel model);
        string Import(string path, ImportViewModel model);
    }
}