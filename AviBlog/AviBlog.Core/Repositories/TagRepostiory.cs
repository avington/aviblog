using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class TagRepostiory : ITagRepostiory
    {
        private readonly BlogContext _context;

        public TagRepostiory()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }


        public IQueryable<Tag> GetAllTags()
        {
            return _context.Tags.AsQueryable();
        }
    }
}