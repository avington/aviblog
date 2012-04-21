using System;
using System.Linq;
using System.Net;
using AviBlog.Core.Net;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class GoodreadsService : IGoodreadsService
    {
        private const string GoodReadsShowUrl = "http://www.goodreads.com/user/show/";
        private readonly IGoodReadsXmlMappingService _goodReadsXmlMappingService;
        private readonly IHttpRequestHelper _httpRequestHelper;
        private readonly ISettingsService _settingsService;

        public GoodreadsService(ISettingsService settingsService, IHttpRequestHelper httpRequestHelper,
                                IGoodReadsXmlMappingService goodReadsXmlMappingService)
        {
            _settingsService = settingsService;
            _httpRequestHelper = httpRequestHelper;
            _goodReadsXmlMappingService = goodReadsXmlMappingService;
        }

        public GoodReadsUserShowViewModel GetGoodReadsTimeline(int take)
        {
            SettingViewModel keyModel = _settingsService.GetSettingByKey("GoodReadsKey");
            SettingViewModel userIdModel = _settingsService.GetSettingByKey("GoodReadsUserId");
            string key = string.Empty ;
            string userId = string.Empty;
            if (keyModel != null)key = keyModel.Entry;            
            if (userIdModel != null) userId = userIdModel.Entry;
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(userId))return null;
            string url = GoodReadsShowUrl + userId + ".xml?key=" + key;
            HttpWebRequest request = _httpRequestHelper.GetRequest(url, string.Empty, "GET");
            string response = _httpRequestHelper.GetResponse(request);
            GoodReadsUserShowViewModel view = _goodReadsXmlMappingService.MapToViewModel(response);
            view.Updates = view.Updates.Take(take).ToList();
            return view;
        }
    }
}