using System;

namespace Core.ServiceContract.Security.Jwt
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
        Guid CreateCryptographicallySecureGuid();
    }
}