using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class ProfileUserService : IProfileUserService
    {
        private readonly IUserProfileMappingService _mappingService;
        private readonly IProfileUserRepository _profileUserRepository;

        public ProfileUserService(IProfileUserRepository profileUserRepository,
                                  IUserProfileMappingService mappingService)
        {
            _profileUserRepository = profileUserRepository;
            _mappingService = mappingService;
        }

        #region IProfileUserService Members

        public IList<UserViewModel> GetAllUsers()
        {
            List<UserProfile> users = _profileUserRepository.GetUserProfiles().ToList();
            var viewList = new List<UserViewModel>();
            foreach (UserProfile user in users)
            {
                viewList.Add(_mappingService.MapView(user));
            }

            return viewList;
        }

        public string AddUser(UserViewModel user)
        {
            UserProfile profile = _mappingService.MapEntity(user);
            return _profileUserRepository.AddUserProfile(profile);
        }

        public UserRolesViewModel GetUserRoles(string userName)
        {
            UserProfile user = _profileUserRepository.GetUserProfiles()
                .FirstOrDefault(x => x.UserName == userName);
            IList<UserRole> roles = _profileUserRepository.GetAllRoles();

            UserRolesViewModel view = _mappingService.MapUserRoles(user,roles);
            return view;
        }

        #endregion
    }
}