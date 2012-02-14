using System.Collections.Generic;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IProfileUserService
    {
        IList<UserViewModel> GetAllUsers();
        string AddUser(UserViewModel user);
        UserRolesViewModel GetUserRoles(string userName);
        string UpdateUserRoles(UserRolesViewModel userRolesViewModel);
        UserViewModel GetUserById(int id);
        string DeleteUserById(int id);
        UserRolesViewModel GetUserRolesById(int id);
        string UpdateUser(UserViewModel viewModel);
    }
}   