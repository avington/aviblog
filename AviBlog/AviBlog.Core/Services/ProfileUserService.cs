using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AviBlog.Core.Entities;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class ProfileUserService : IProfileUserService
    {
        private readonly IProfileUserRepository _profileUserRepository;

        public ProfileUserService(IProfileUserRepository profileUserRepository)
        {
            _profileUserRepository = profileUserRepository;
        }

        public IList<UserViewModel> GetAllUsers()
        {
            var users = _profileUserRepository.GetUserProfiles().ToList();
            var viewList = new List<UserViewModel>();
            foreach (var user in users)
            {
                viewList.Add(Mapper.Map<UserProfile,UserViewModel>(user));
            }
            
            return viewList;
        }
    }


}