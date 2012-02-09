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
    }
}