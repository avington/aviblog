using System.Collections.Generic;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public interface IUserProfileMappingService
    {
        UserProfile MapEntity(UserViewModel view);
        UserViewModel MapView(UserProfile entity);
        UserRolesViewModel MapUserRoles(UserProfile user, IList<UserRole> roles);
    }
}