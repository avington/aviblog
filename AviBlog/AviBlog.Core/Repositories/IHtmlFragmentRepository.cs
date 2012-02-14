using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface IHtmlFragmentRepository
    {
        IQueryable<HtmlFragmentLocation> GetAllHtmlPageLocations();
        IQueryable<HtmlFragment> GetHtmlFragmentsByBlogId(int blogId);

        string AddHtmlFragment(HtmlFragment entity, int blogId, string selectedLocationId);
    }
}