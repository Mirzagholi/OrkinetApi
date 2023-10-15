using System;

namespace Core.Models.Model.Security
{
    public class UserToken
    {
        public string AccessTokenHash { get; set; }

        public DateTime AccessTokenExpiresDateTime { get; set; }

        public string RefreshTokenIdHash { get; set; }

        public string RefreshTokenIdHashSource { get; set; }

        public DateTime RefreshTokenExpiresDateTime { get; set; }

        public int UserId { get; set; }
    }
}