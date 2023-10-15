using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace OfoghAds.ConfigLayer.IocConfig
{
    public static class AddCustomHstsExtensions
    {
        public static void UseCustomHsts(this IApplicationBuilder app)
        {
            app.UseHsts();
        }

        public static void AddCustomHsts(this IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.MaxAge = TimeSpan.FromDays(100);
                options.IncludeSubDomains = true;
                options.Preload = true;
            });
        }
    }
}