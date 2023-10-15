using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc
{
    public static class AddCustomAntiforgeryExtensions
    {
        public static void AddCustomAntiforgery(this IServiceCollection services)
        {
            services.AddAntiforgery(x => x.HeaderName = "X-XSRF-TOKEN");
            services.AddControllers(options =>
            {
                options.UseYeKeModelBinder();
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
        }
    }
}
