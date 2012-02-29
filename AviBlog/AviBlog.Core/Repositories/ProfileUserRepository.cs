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
                _context.Dispose();
                return string.Empty;
            }
            return "User already exists.";

        }

        public IList<UserRole> GetAllRoles()
        {
            return _context.UserRoles.ToList();
        }

        public string RemoveAllUserRoles(string userName)
        {
            var user = _context.UserProfiles.FirstOrDefault(x => x.UserName == userName);
            if (user == null) return "The specified user could not be found.";
            user.Roles.Clear();
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string AddUserRoles(IEnumerable<string> roleIds, string userName )
        {
            if (string.IsNullOrEmpty(userName)) return "No User was provided to add roles to.";
            if (roleIds == null) return string.Empty;
            
            var user = _context.UserProfiles
                .FirstOrDefault(x => x.UserName == userName);

            if (user == null) return "The specified user could not be found.";
            foreach (string roleId in roleIds)
            {
                int id;
                if (! int.TryParse(roleId,out id))
                    continue;

                var role = _context.UserRoles.FirstOrDefault(x => x.Id == id);
                if (role == null) continue;

                user.Roles.Add(role);
            }
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string DeleteUser(int id)
        {
            var user = _context.UserProfiles.FirstOrDefault(x => x.Id == id);
            if (user == null) return "The specified user could not found.";
            _context.UserProfiles.Remove(user);
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string UpdateUserProfile(UserProfile userProfile)
        {
            var user = _context.UserProfiles.FirstOrDefault(x => x.Id == userProfile.Id);
            if (user == null) return "The specified user could not be found.";
            user.Email = userProfile.Email;
            user.FirstName = userProfile.FirstName;
            user.Password = userProfile.Password;
            user.UserName = userProfile.UserName;
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public UserProfile GetUserById(int sectedUserId)
        {
            return _context.UserProfiles.Find(sectedUserId);
        }
    }
}