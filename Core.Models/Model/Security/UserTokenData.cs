using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Models.Model.Security
{
    public class UserTokenData
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenSerial { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}