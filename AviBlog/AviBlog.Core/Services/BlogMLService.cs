using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using AviBlog.Core.Application;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;
using BlogML.Xml;

namespace AviBlog.Core.Services
{
    public class BlogMLService : IBlogMLService
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IImportRepository _importRepository;
        private readonly IStreamHelper _streamHelper;
        private readonly IBlogMLMappingService _blogMLMappingService;

        public BlogMLService(IHttpHelper httpHelper, IStreamHelper streamHelper, 
                             IImportRepository importRepository, IBlogMLMappingService blogMLMappingService)
        {
            _httpHelper = httpHelper;
            _streamHelper = streamHelper;
  
            _importRepository = importRepository;
            _blogMLMappingService = blogMLMappingService;
        }

        #region IBlogMLService Members

        public string SaveAndImport(IList<HttpPostedFileBase> files, ImportViewModel model)
        {
            if (files == null || !files.Any()) return "No files were provided";

            string fileName = Path.GetFileName(files[0].FileName);
            string path = _httpHelper.GetPath("~/App_Data/blogml", fileName);
            files[0].SaveAs(path);
            string errorMessage = Import(path, model);
            return errorMessage;
        }

        public string Import(string path, ImportViewModel model)
        {
            XmlTextReader xmlStream = _streamHelper.StringToXmlReader(path);
            BlogMLBlog blogMl = BlogMLSerializer.Deserialize(xmlStream);
            IList<Post> posts = _blogMLMappingService.MapToEntity(blogMl);
            string errorMessage = _importRepository.ImportPosts(posts, model.SelectedBlogSite, model.SelectedUserId);
            return errorMessage;
        }

        #endregion
    }
}