using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Models.Model.Security
{
    public class UserTokenResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}