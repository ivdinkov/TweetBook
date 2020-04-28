using Core22.Domain;
using System.Threading.Tasks;

namespace Core22.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegiterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
