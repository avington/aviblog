using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepostiory _tagRepostiory;


        public TagService(ITagRepostiory tagRepostiory)
        {
            _tagRepostiory = tagRepostiory;
        }

        #region ITagService Members

        public IList<TagCloudViewModel> GetTagCloud()
        {
            var qry = from x in _tagRepostiory.GetAllTags()
                      where x.TagName != ""
                      group x by x.TagName
                      into grp
                      select new
                                 {
                                     Name = grp.Key,
                                     Count = grp.Count()
                                 };

            var list = new List<TagCloudViewModel>();
            foreach (var item in qry)
            {
                var tag = new TagCloudViewModel();
                tag.TagName = item.Name;
                tag.TagCount = item.Count;
                if (tag.TagCount <= 0) continue;
                if (tag.TagCount < 3) tag.Weight = 1;
                if (tag.TagCount >= 3 && tag.TagCount < 5) tag.Weight = 2;
                if (tag.TagCount >= 5) tag.Weight = 3;
                list.Add(tag);
            }
            return list;
        }

        #endregion
    }
}