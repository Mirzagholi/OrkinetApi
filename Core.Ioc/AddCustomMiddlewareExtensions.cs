using Core.Common.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Core.Ioc
{
    public static class AddCustomMiddlewareExtensions
    {
        public static void UseCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        }
    }
}
