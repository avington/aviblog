using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Mappings
{
    public class UserProfileMappingService : IUserProfileMappingService
    {
        #region IUserProfileMappingService Members

        public UserProfile MapEntity(UserViewModel view)
        {
            return Mapper.Map<UserViewModel, UserProfile>(view);
        }

        public UserViewModel MapView(UserProfile entity)
        {
            return Mapper.Map<UserProfile, UserViewModel>(entity);
        }

        public UserRolesViewModel MapUserRoles(UserProfile user, IList<UserRole> roles)
        {
            if (user == null) return new UserRolesViewModel();
            var view = new UserRolesViewModel
                           {
                               FirstName = user.FirstName,
                               LastName = user.LastName,
                               UserName = user.UserName,
                               Roles = new List<RolesViewModel>()
                           };

            foreach (UserRole role in roles)
            {
                RolesViewModel roleView = Mapper.Map<UserRole, RolesViewModel>(role);
                foreach (UserRole userRole in user.Roles)
                {
                    roleView.IsChecked = userRole.Id == role.Id;
                   
                }
                view.Roles.Add(roleView);

            }


            var selectRoles = new MultiSelectList(view.Roles, "RoleId", "RoleName",
                view.Roles
                .Where(x => x.IsChecked)
                .Select(x =>x.RoleId));

            view.MultiSelectRoles = selectRoles;

            return view;
        }

        #endregion
    }
}