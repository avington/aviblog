using AviBlog.Core.ViewModel;

namespace AviBlog.Core.Services
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(SignInViewModel view);
    }
}