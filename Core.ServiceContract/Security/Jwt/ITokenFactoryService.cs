using Core.Models.Model.Security;
using System.Threading.Tasks;

namespace Core.ServiceContract.Security.Jwt
{
    public interface ITokenFactoryService
    {
        Task<UserTokenData> CreateJwtTokensAsync(User user);
        string GetRefreshTokenSerial(string refreshTokenValue);
    }
}