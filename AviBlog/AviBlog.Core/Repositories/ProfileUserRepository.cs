using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class ProfileUserRepository : IProfileUserRepository
    {

        private readonly BlogContext _context;

        public ProfileUserRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }

        public IQueryable<UserProfile> GetUserProfiles()
        {
            return _context.UserProfiles.AsQueryable();
        }
    }
}