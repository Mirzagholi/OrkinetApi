using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Common.ShareContract;

namespace Core.Common.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IServiceResultHelper serviceResultHelper)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                serviceResultHelper.Response(ex,context);
            }
        }

    }
}
