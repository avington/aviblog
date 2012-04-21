using System.Collections.Generic;
using System.Xml.Linq;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class GoodReadsXmlMappingService : IGoodReadsXmlMappingService
    {
        #region IGoodReadsXmlMappingService Members

        public GoodReadsUserShowViewModel MapToViewModel(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;
            var view = new GoodReadsUserShowViewModel {Updates = new List<GoodReadsUpdateViewModel>()};
            XDocument doc = XDocument.Parse(xml);
            IEnumerable<XElement> user = doc.Descendants("user").Elements();
            foreach (XElement element in user)
            {
                if (element.Name == "id") view.UserId = element.Value;
                if (element.Name == "user_name") view.UserName = element.Value;
                if (element.Name == "link") view.UserLink = element.Value;
                if (element.Name == "image_url") view.UserImageUrl = element.Value;
                if (element.Name == "small_image_url") view.UserImageSmallUrl = element.Value;
                if (element.Name == "about") view.UserImageSmallUrl = element.Value;
                if (element.Name == "location") view.UserImageSmallUrl = element.Value;
                if (element.Name == "name") view.Name = element.Value;
                if (element.Name == "updates")
                {
                    foreach (var update in element.Elements())
                    {
                        var updateView = new GoodReadsUpdateViewModel();
                        var xAttribute = update.Attribute("type");
                        if (xAttribute != null) updateView.ActionType = xAttribute.Value;
                        foreach (var item in update.Elements())
                        {
                            if (item.Name == "action_text") updateView.ActionText = item.Value;
                            if (item.Name == "image_url") updateView.BookImageUrl = item.Value;
                            updateView.Name = view.Name;
                            updateView.UserLink = view.UserLink;
                        }                       
                        view.Updates.Add(updateView);
                    }
                }
            }
            return view;
        }

        #endregion
    }
}