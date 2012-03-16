using System.Collections.Generic;
using System.Web;
using AviBlog.Core.Application;

namespace AviBlog.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IHttpHelper _httpHelper;

        public UploadService(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public void Upload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null) return;
            foreach (var file in files)
            {
                if (file.ContentLength <= 0) continue;
                string fileName = _httpHelper.GetPath("~/content/assets/blog1", file.FileName);
                file.SaveAs(fileName);
            }
        }
    }
}