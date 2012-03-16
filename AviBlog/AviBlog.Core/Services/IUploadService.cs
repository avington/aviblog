using System.Collections.Generic;
using System.Web;

namespace AviBlog.Core.Services
{
    public interface IUploadService
    {
        void Upload(IEnumerable<HttpPostedFileBase> files);
    }
}