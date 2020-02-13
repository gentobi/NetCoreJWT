using NetCoreAuth.Models.ViewModels;

namespace NetCoreAuth.Infrastructures.Services
{
    public interface IAuthenticationService
    {
        string Authenticate(AuthenticationModel input);
    }
}
