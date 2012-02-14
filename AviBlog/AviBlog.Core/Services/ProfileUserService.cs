using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Encryption;
using AviBlog.Core.Entities;
using AviBlog.Core.Mappings;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class ProfileUserService : IProfileUserService
    {
        private readonly IEncryptionHelper _encryptionHelper;
        private readonly IUserProfileMappingService _mappingService;
        private readonly IProfileUserRepository _profileUserRepository;

        public ProfileUserService(IProfileUserRepository profileUserRepository,
                                  IUserProfileMappingService mappingService, IEncryptionHelper encryptionHelper)
        {
            _profileUserRepository = profileUserRepository;
            _mappingService = mappingService;
            _encryptionHelper = encryptionHelper;
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
            profile.Password = _encryptionHelper.Encrypt(user.Password);
            return _profileUserRepository.AddUserProfile(profile);
        }

        public UserRolesViewModel GetUserRoles(string userName)
        {
            UserProfile user = _profileUserRepository.GetUserProfiles()
                .FirstOrDefault(x => x.UserName == userName);
            UserRolesViewModel view = MapUserToRoles(user);
            return view;
        }

        public string UpdateUserRoles(UserRolesViewModel userRolesViewModel)
        {
            string errorMessage = _profileUserRepository.RemoveAllUserRoles(userRolesViewModel.UserName);
            if (!string.IsNullOrEmpty(errorMessage))
                return errorMessage;
            errorMessage = _profileUserRepository.AddUserRoles(userRolesViewModel.SelectedRoleIds,
                                                               userRolesViewModel.UserName);
            return errorMessage;
        }

        public UserViewModel GetUserById(int id)
        {
            UserProfile user = _profileUserRepository.GetUserProfiles().FirstOrDefault(x => x.Id == id);
            if (user == null) return new UserViewModel {ErrorMessage = "User was not found."};
            UserViewModel view = _mappingService.MapView(user);
            return view;
        }

        public string DeleteUserById(int id)
        {
            return _profileUserRepository.DeleteUser(id);
        }

        public UserRolesViewModel GetUserRolesById(int id)
        {
            UserProfile user = _profileUserRepository.GetUserProfiles()
                .FirstOrDefault(x => x.Id == id);
            UserRolesViewModel view = MapUserToRoles(user);
            return view;
        }

        public string UpdateUser(UserViewModel viewModel)
        {
            UserProfile userProfile = _mappingService.MapEntity(viewModel);
            userProfile.Password = _encryptionHelper.Encrypt(viewModel.Password);
            string errorMessage = _profileUserRepository.UpdateUserProfile(userProfile);
            return errorMessage;
        }

        #endregion

        private UserRolesViewModel MapUserToRoles(UserProfile user)
        {
            if (user == null) return new UserRolesViewModel();
            IList<UserRole> roles = _profileUserRepository.GetAllRoles();

            UserRolesViewModel view = _mappingService.MapUserRoles(user, roles);
            return view;
        }
    }
}