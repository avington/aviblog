using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class HtmlFragmentRepository : IHtmlFragmentRepository
    {
        private BlogContext _context;

        public HtmlFragmentRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }

        public IQueryable<HtmlFragmentLocation> GetAllHtmlPageLocations()
        {
            return _context.HtmlFragmentLocations.AsQueryable();
        }

        public IQueryable<HtmlFragment> GetHtmlFragmentsByBlogId(int blogId)
        {
            return _context.HtmlFragments
                .Where(x => x.Id == blogId);
        }

        public string AddHtmlFragment(HtmlFragment entity, int blogId, string selectedLocationId)
        {
            if (entity == null) return "The entity was not provided.";

            Blog blog = _context.Blogs.Find(blogId);
            if (blog == null) return "the specified blog was not found.";

            int locationId;
            if (!int.TryParse(selectedLocationId,out locationId)) locationId = 0;

            HtmlFragmentLocation location = _context.HtmlFragmentLocations.Find(locationId);
            if (location == null) return "The specified web page location was not found.";

            entity.Location = location;

            if (blog.HtmlFragments == null) blog.HtmlFragments = new Collection<HtmlFragment>();
            blog.HtmlFragments.Add(entity);
            _context.SaveChanges();
            return string.Empty;
        }

        public string DeleteHtmlFragment(int id)
        {
            var fragment = _context.HtmlFragments.Find(id);
            if (fragment == null) return "The specified html fragment could not be found.";
            _context.HtmlFragments.Remove(fragment);
            _context.SaveChanges();
            return string.Empty;
        }

        public IQueryable<HtmlFragment> GetAllHtmlFragments()
        {
            return _context.HtmlFragments.AsQueryable();
        }

        public string UpdateHtmlFragment(HtmlFragment entity, int blogId, string selectedLocationId)
        {
            if (entity == null) return "The html fragment object to be updated was not provided";
            var blog = _context.Blogs.Find(blogId);
            if (blog == null) return "The parent blog for the html fragment to be updated was not found.";

            int locationId;
            if (!int.TryParse(selectedLocationId, out locationId))
                locationId = 0;

            var location = _context.HtmlFragmentLocations.Find(locationId);
            var htmlFragment = blog.HtmlFragments.FirstOrDefault(x => x.Id == entity.Id);
            if (htmlFragment == null) return "The specifed html fragment was not found.";
            htmlFragment.Location = location;
            htmlFragment.Name = entity.Name;
            htmlFragment.ScriptBody = entity.ScriptBody;
            _context.SaveChanges();
            return string.Empty;
        }
    }
}