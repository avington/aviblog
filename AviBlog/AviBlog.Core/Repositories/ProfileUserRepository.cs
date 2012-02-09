using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

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

        public string AddUserProfile(UserProfile user)
        {
            if (! _context.UserProfiles.Any(x => x.UserName == user.UserName))
            {
                _context.UserProfiles.Add(user);
                _context.SaveChanges();
                return string.Empty;
            }
            return "User already exists.";

        }

        public IList<UserRole> GetAllRoles()
        {
            return _context.UserRoles.ToList();
        }
    }
}