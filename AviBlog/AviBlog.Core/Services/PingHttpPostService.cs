using System.Linq;
using AviBlog.Core.Application;
using AviBlog.Core.Entities;
using AviBlog.Core.Repositories;

namespace AviBlog.Core.Services
{
    public class PingHttpPostService : IPingHttpPostService
    {
        private readonly IBlogSiteRepository _blogSiteRepository;
        private readonly IHttpHelper _httpHelper;
        private readonly IPingRepository _pingRepository;
        private readonly IPingWebRequestHelper _pingWebRequestHelper;

        public PingHttpPostService(IPingRepository pingRepository, IPingWebRequestHelper pingWebRequestHelper,
                                   IBlogSiteRepository blogSiteRepository, IHttpHelper httpHelper)
        {
            _pingRepository = pingRepository;
            _pingWebRequestHelper = pingWebRequestHelper;
            _blogSiteRepository = blogSiteRepository;
            _httpHelper = httpHelper;
        }

        public void Ping(Post entity)
        {
            IQueryable<PingService> pingList = _pingRepository.GetAll();

            //for now get the default blog name;
            Blog blog = _blogSiteRepository.GetAllBlogs().FirstOrDefault(x => x.IsActive && x.IsPrimary);
            string blogName = blog != null ? blog.BlogName : "Steven Moseley";

            foreach (PingService pingService in pingList)
            {
                _pingWebRequestHelper.Send(pingService.PingUrl, _httpHelper.GetUrl(entity.Slug).ToString(), blogName);
            }
        }
    }
}