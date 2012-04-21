using System;
using System.Collections.Generic;

namespace AviBlog.Core.ViewModel
{
    public class GoodReadsUserShowViewModel : BaseViewModel
    {
        public string UserId;
        public string UserName { get; set; }
        public string Name { get; set; }
        public string UserLink { get; set; }
        public string UserImageUrl { get; set; }
        public string UserImageSmallUrl { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public DateTime DateJoined { get; set; }
        public IList<GoodReadsUpdateViewModel> Updates { get; set; }
    }
}