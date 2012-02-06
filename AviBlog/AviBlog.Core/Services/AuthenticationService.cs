using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using AviBlog.Core.Encryption;
using AviBlog.Core.Entities;
using AviBlog.Core.Repositories;
using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEncryptionHelper _encryptionHelper;
        private readonly IProfileUserRepository _profileUserRepository;

        public AuthenticationService(IProfileUserRepository profileUserRepository, IEncryptionHelper encryptionHelper)
        {
            _profileUserRepository = profileUserRepository;
            _encryptionHelper = encryptionHelper;
        }

        #region IAuthenticationService Members

        public bool AuthenticateUser(SignInViewModel view)
        {
            UserProfile user = _profileUserRepository.GetUserProfiles().FirstOrDefault(x => x.UserName == view.UserName);
            if (user == null) return false;

            if (_encryptionHelper.CheckPassword(user.Password, view.Password))
            {
                if (user.Roles == null) return false;

                List<UserRole> roles = user.Roles.ToList();

                //get user's roles then convert them to a delimited string and remove the training delimiter
                string roleData = roles.Aggregate(string.Empty,
                                                  (current, role) => current + (string.Format("{0}~", role.RoleName)));
                if (roleData.Length > 0) roleData = roleData.Substring(0, roleData.Length - 1);

                var ticket = new FormsAuthenticationTicket(
                    1,
                    FormsAuthentication.FormsCookieName,
                    DateTime.Now,
                    DateTime.Now.AddMonths(1),
                    true,
                    roleData
                    );

                string cookieContents = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                                 {
                                     Expires = ticket.Expiration,
                                     Path = FormsAuthentication.FormsCookiePath
                                 };

                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }
            return false;
        }

        #endregion
    }
}