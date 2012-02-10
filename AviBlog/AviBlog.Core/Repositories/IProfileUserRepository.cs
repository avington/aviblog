using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Repositories
{
    public interface IProfileUserRepository
    {
        IQueryable<UserProfile> GetUserProfiles();
        string AddUserProfile(UserProfile user);
        IList<UserRole> GetAllRoles();
        string RemoveAllUserRoles(string userName);
        string AddUserRoles(IEnumerable<string> roleIds, string userName );
        string DeleteUser(int id);
    }
}