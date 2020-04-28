using System.Collections.Generic;

namespace Core22.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string RefreshToken { get; set; }
    }
}
