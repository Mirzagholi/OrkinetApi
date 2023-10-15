using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.ServiceContract.Security.Jwt
{
    public interface IAntiForgeryCookieService
    {
        void RegenerateAntiForgeryCookies(IEnumerable<Claim> claims);
        void DeleteAntiForgeryCookies();
    }
}