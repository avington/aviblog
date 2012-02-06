using System.Collections.Generic;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IProfileUserService
    {
        IList<UserViewModel> GetAllUsers();
    }
}