using Core22.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegiterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
