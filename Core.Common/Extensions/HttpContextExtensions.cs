using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Core.Common.Extensions
{
    public static class HttpContextExtensions
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static int? GetProviderId()
        {
            var providerId = _httpContextAccessor.HttpContext.User.Claims.ToList().FirstOrDefault(x => x.Type.Contains("ProviderId"));
            if (providerId == null)
                return null;

            return int.Parse(providerId.Value);
        }

        public static int? GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.ToList().FirstOrDefault(x => x.Type.Contains(ClaimTypes.NameIdentifier));
            if (userId == null)
                return null;

            return int.Parse(userId.Value);
        }

        public static string GetRole()
        {
            var role = _httpContextAccessor.HttpContext.User.Claims.ToList().FirstOrDefault(x => x.Type.Contains(ClaimTypes.Role));
            if (role == null)
                return null;

            return role.Value;
        }

        //public static string GetUserMobile()
        //{
        //    var user = _httpContextAccessor.HttpContext.User.Claims.ToList();
        //    return user.FirstOrDefault(x => x.Type.Contains("MobilePhone".ToLower())).Value;
        //}

        //    public static string GetUserIp(this HttpContext httpContext)
        //    {
        //        var request = httpContext.Request;
        //        return request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
        //    }

        //    public static string GetSecurityStamp(this IIdentity iidentity)
        //    {
        //        return
        //            ((ClaimsIdentity)iidentity).FindFirst("SecurityStamp").Value;
        //    }

        //    public static void DisableBrowserCache(this HttpContext httpContext)
        //    {
        //        httpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        //        httpContext.Response.Cache.SetValidUntilExpires(false);
        //        httpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //        httpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        httpContext.Response.Cache.SetNoStore();
        //    }
    }
}